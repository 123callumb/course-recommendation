import { createBrowserHistory } from 'history';
import { createStore, applyMiddleware } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import { routerMiddleware } from 'connected-react-router';
import { RootReducer } from './reducer';

export const AppHistory = createBrowserHistory();

export const DataStore = (preloadedState?: any) => createStore(
    RootReducer(AppHistory),
    preloadedState,
    composeWithDevTools(
        applyMiddleware(
            routerMiddleware(AppHistory)
        )
    )
);
