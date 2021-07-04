import { ArrowBackIcon, ArrowForwardIcon, StarIcon } from "@chakra-ui/icons";
import { Box, Button, Container, Progress, Text } from "@chakra-ui/react";
import React from "react";
import { connect } from "react-redux";
import Section_Comp from "../Components/Section/Section_Comp";
import Section from "../Models/Section";
import RequestManager, { RequestURL } from "../Services/RequestManager";
import { AnswerSet } from "../Store/AnswerStore";
import { AppState } from "../Store/reducer";

interface QuestionPage_Props {
    AnswerSet: AnswerSet[];
}

interface QuestionPage_State {
    Sections: Section[];
    SectionPosition: number;
}

class QuestionPage_Comp extends React.Component<QuestionPage_Props, QuestionPage_State> {
    constructor(props: QuestionPage_Props) {
        super(props);

        this.state = {
            Sections: [],
            SectionPosition: 0
        };

        this.LoadQuestions();
    }

    async LoadQuestions() {
        const res = await RequestManager.MakeRequest<Section[]>(RequestURL.Home_Load, "GET", null, true);

        if (res.success) {
            this.setState({
                Sections: res.data
            });
        }
    }

    GetCurrentSection() {
        return this.state.Sections[this.state.SectionPosition];
    }

    GetSectionAnswerSet() {
        const sectionID = this.GetCurrentSection().SectionID;
        return this.props.AnswerSet.filter(f => f.SectionID === sectionID);
    }

    render() {
        return (<Container maxW="container.md">
            <Text size="md">Question progress:</Text>
            <Progress value={((this.state.SectionPosition + 1) / this.state.Sections.length) * 100} />
            {
                this.state.Sections.length === 0 ? <Box boxShadow="xs" p="4" mt="4">
                    <Text size="l" mb="2">Loading Questions...</Text>
                    <Progress size="xs" isIndeterminate />
                </Box>
                    :
                    <Section_Comp section={this.GetCurrentSection()} sectionAnswers={this.GetSectionAnswerSet()} />
            }
            <Box mt="4">
                {this.state.SectionPosition > 0 ? <Button colorScheme="teal" onClick={() => this.setState({ SectionPosition: this.state.SectionPosition - 1 })} leftIcon={<ArrowBackIcon />}>Previous Question</Button> : null}
                {this.state.SectionPosition === (this.state.Sections.length - 1) ?
                    <Button float="right" colorScheme="teal" rightIcon={<StarIcon />}>View Recommendation</Button>
                    :
                    <Button float="right" colorScheme="teal" onClick={() => this.setState({ SectionPosition: this.state.SectionPosition + 1 })} rightIcon={<ArrowForwardIcon />}>Next Question</Button>
                }
            </Box>
        </Container>)
    }
}

export default connect((state: AppState, props: QuestionPage_Props): QuestionPage_Props => ({
    AnswerSet: state.answers
}))(QuestionPage_Comp);
