import { createBrowserHistory } from 'history';
import { createStore, applyMiddleware, DeepPartial } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import { routerMiddleware } from 'connected-react-router';
import { AppState, RootReducer } from './Reducer';

export const AppHistory = createBrowserHistory();

export const DataStore = (preloadedState?: DeepPartial<AppState>) => createStore(
    RootReducer(AppHistory),
    preloadedState,
    composeWithDevTools(
        applyMiddleware(
            routerMiddleware(AppHistory)
        )
    )
);
