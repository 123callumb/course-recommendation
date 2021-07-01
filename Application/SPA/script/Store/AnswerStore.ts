const Answers_Set_Action = "ACTION_SET_ANSWER";

export interface AnswerSet {
    SectionID: number;
    QuestionID?: number;
    AnswerID: number;
}

interface AnswersSetAction {
    type: typeof Answers_Set_Action;
    payload: AnswerSet;
}

export function SetAnswerSet(sectionID: number, answerID: number, questionID: number = null): AnswersSetAction {
    return {
        type: Answers_Set_Action,
        payload: {
            AnswerID: answerID,
            SectionID: sectionID,
            QuestionID: questionID
        }
    }
}


export function AnswersReducer(state: AnswerSet[], action: AnswersSetAction) {
    switch (action.type) {
        case Answers_Set_Action:
            const toSet = action.payload;
            const exisitngAnswer = state.find(f => f.SectionID === toSet.SectionID && (toSet.QuestionID === null || toSet.QuestionID === f.QuestionID));

            if (exisitngAnswer)
                exisitngAnswer.AnswerID = toSet.AnswerID;
            else
                state.push(toSet);

            return state;
        default:
            return state;
    }
}
