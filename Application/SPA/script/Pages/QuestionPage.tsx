import { ArrowBackIcon, ArrowForwardIcon, StarIcon } from "@chakra-ui/icons";
import { Box, Button, Container, Progress, Text } from "@chakra-ui/react";
import React from "react";
import { connect } from "react-redux";
import Section_Comp from "../Components/Section/Section_Comp";
import HomeLoadResponse from "../Models/Responses/HomeLoadResponse";
import Section from "../Models/Section";
import RequestManager, { PageRoute, RequestURL } from "../Services/RequestManager";
import { AnswerSet, SetAnswerSetState } from "../Store/AnswerStore";
import { AppState } from "../Store/reducer";

interface QuestionPage_Props {
    AnswerSet: AnswerSet[];
    SetAnswerSetState?: typeof SetAnswerSetState;
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

        // TODO: find a nicer way to reset the session storage, this is just for people 
        // whom feel the need  to refresh the page on the recommendation page.
        // Probably add it to the session storage on server...
        sessionStorage['recommendation_session'] = undefined;
        this.LoadQuestions();
    }

    async LoadQuestions() {
        const res = await RequestManager.MakeRequest<HomeLoadResponse>(RequestURL.Home_Load, "GET", null, true);

        if (res.success) {
            this.props.SetAnswerSetState(res.data.SessionAnswerSets);
            this.setState({
                Sections: res.data.Sections
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
        return (<>
            <Container maxW="container.md">
                {
                    this.state.Sections.length === 0 ? <Box boxShadow="xs" p="4" mt="4">
                        <Text size="l" mb="2">Loading Questions...</Text>
                        <Progress size="xs" isIndeterminate />
                    </Box>
                        :
                        <Section_Comp section={this.GetCurrentSection()} sectionAnswers={this.GetSectionAnswerSet()} />
                }
            </Container>
            <Box position="fixed" textAlign="center" bottom="4" width="100%">
                <Container maxW="container.md">
                    <Progress value={((this.state.SectionPosition + 1) / this.state.Sections.length) * 100} size="sm"/>
                    <Box boxShadow="md" p="2">
                        {this.state.SectionPosition > 0 ? <Button float="left" colorScheme="teal" onClick={() => this.setState({ SectionPosition: this.state.SectionPosition - 1 })} leftIcon={<ArrowBackIcon />}>Previous</Button> : null}
                        <Box textAlign="right">
                            {this.state.SectionPosition === (this.state.Sections.length - 1) ?
                                <Button
                                    colorScheme="linkedin"
                                    rightIcon={<StarIcon />}
                                    onClick={() => RequestManager.ChangeURL(PageRoute.Recommendation)}
                                >Submit</Button>
                                :
                                <Button colorScheme="teal" onClick={() => this.setState({ SectionPosition: this.state.SectionPosition + 1 })} rightIcon={<ArrowForwardIcon />}>Next</Button>
                            }
                        </Box>
                    </Box>
                </Container>
            </Box>
        </>)
    }
}

export default connect((state: AppState, props: QuestionPage_Props): QuestionPage_Props => ({
    AnswerSet: state.answers
}), {
    SetAnswerSetState
})(QuestionPage_Comp);
