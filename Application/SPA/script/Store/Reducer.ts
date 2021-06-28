import { connectRouter, RouterState } from "connected-react-router";
import { combineReducers } from "redux";
import { History } from "history";

export interface AppState {
    router: RouterState;
}

export let RootReducer = (history: History) => combineReducers<AppState>({
    router: connectRouter(history)
});
