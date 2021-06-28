import React from "react";
import { Question } from "../Models/Question";
import RequestManager, { RequestURL } from "../Services/RequestManager";

export class QuestionPage extends React.Component {
    constructor(props: any) {
        super(props);

        this.LoadQuestions();
    }

    async LoadQuestions() {
        const res = await RequestManager.MakeRequest<Question[]>(RequestURL.Question_LoadAll, "GET", null, true);

        if (res.success) {
            console.log(res.data);
        }
    }

    render() {
        return (<div>
                <div>This is the question page yeeee</div>
            </div>)
    }
}
