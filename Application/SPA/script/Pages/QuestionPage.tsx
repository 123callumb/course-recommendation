import { Container } from "@chakra-ui/react";
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
}

class QuestionPage_Comp extends React.Component<QuestionPage_Props, QuestionPage_State> {
    constructor(props: QuestionPage_Props) {
        super(props);

        this.state = {
            Sections: []
        };

        this.LoadQuestions();
    }

    async LoadQuestions() {
        const res = await RequestManager.MakeRequest<Section[]>(RequestURL.Question_LoadAll, "GET", null, true);

        if (res.success) {
            this.setState({
                Sections: res.data
            });
        }
    }

    GetSectionAnswerSet(sectionID: number) {
        return this.props.AnswerSet.filter(f => f.SectionID === sectionID);
    }

    render() {
        return (<Container maxW="container.md">
            {this.state.Sections.map(e => <Section_Comp key={e.SectionID} section={e} sectionAnswers={this.GetSectionAnswerSet(e.SectionID)}  />)}
        </Container>)
    }
}

export default connect((state: AppState, props: QuestionPage_Props): QuestionPage_Props => ({
    AnswerSet: state.answers
}))(QuestionPage_Comp);
