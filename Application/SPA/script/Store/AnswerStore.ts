import RequestManager, { RequestURL } from "../Services/RequestManager";

const Answers_Set_Action = "ACTION_SET_ANSWER";
const Answers_Set_State_Action = "ACTION_SET_ANSWER_STATE";

export interface AnswerSet {
    SectionID: number;
    QuestionID?: number;
    AnswerID: number;
    GroupID: number;
}

interface AnswersSetAction {
    type: typeof Answers_Set_Action;
    payload: AnswerSet;
}

interface AnswersSetStateAction {
    type: typeof Answers_Set_State_Action;
    payload: AnswerSet[];
}


export function SetAnswerSet(groupID: number, sectionID: number, answerID: number, questionID: number = null): AnswersSetAction {
    return {
        type: Answers_Set_Action,
        payload: {
            AnswerID: answerID,
            SectionID: sectionID,
            QuestionID: questionID,
            GroupID: groupID
        }
    }
}

export function SetAnswerSetState(existingAnswerSet: AnswerSet[]): AnswersSetStateAction {
    return {
        type: Answers_Set_State_Action,
        payload: existingAnswerSet
    }
}


export function AnswersReducer(state: AnswerSet[] = [], action: AnswersSetAction | AnswersSetStateAction) {
    switch (action.type) {
        case Answers_Set_Action:
            const toSet = action.payload;
            const exisitngAnswer = state.find(f => f.SectionID === toSet.SectionID && (toSet.QuestionID === null || toSet.QuestionID === f.QuestionID));

            if (exisitngAnswer)
                exisitngAnswer.AnswerID = toSet.AnswerID;
            else
                state.push(toSet);

            RequestManager.MakeRequest<null, AnswerSet>(RequestURL.AnswerSet_RegisterSessionAnswer, "POST", exisitngAnswer ?? toSet);

            return [...state];
        case Answers_Set_State_Action:
            return action.payload;
        default:
            return state;
    }
}
