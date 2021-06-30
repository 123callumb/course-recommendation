import { Container } from "@chakra-ui/react";
import React from "react";
import Section_Comp from "../Components/Question/Section_Comp";
import Section from "../Models/Section";
import RequestManager, { RequestURL } from "../Services/RequestManager";

interface QuestionPage_State {
    Sections: Section[];
}

export class QuestionPage extends React.Component<any, QuestionPage_State> {
    constructor(props: any) {
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

    render() {
        return (<Container maxW="container.md">
            {this.state.Sections.map(e => <Section_Comp key={e.SectionID} {...e} />)}
        </Container>)
    }
}
