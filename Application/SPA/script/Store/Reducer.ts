import { connectRouter, RouterState } from "connected-react-router";
import { combineReducers } from "redux";
import { History } from "history";
import { AnswerSet, AnswersReducer } from "./AnswerStore";

export interface AppState {
    router: RouterState;
    answers: AnswerSet[];
}

export let RootReducer = (history: History) => combineReducers<AppState>({
    router: connectRouter(history),
    answers: AnswersReducer
});
