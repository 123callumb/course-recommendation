import { ConnectedRouter } from "connected-react-router";
import React from "react";
import { Provider } from "react-redux";
import { Route, Switch } from "react-router";
import { AppHistory, DataStore } from "../Store/Store";
import { History, LocationState } from "history";
import { PageRoute } from "../Services/RequestManager";
import { QuestionPage } from "./QuestionPage";
import { render } from "react-dom";

interface AppRoute_Props<S = LocationState> {
    history: History<S>;
}

class AppRoute extends React.Component<AppRoute_Props> {
    constructor(props: AppRoute_Props) {
        super(props);

    }
    render() {
        return (
            <ConnectedRouter history={this.props.history}>
                <Switch>
                    <Route exact path={PageRoute.Home} component={QuestionPage} />
                </Switch>
            </ConnectedRouter>
        );
    }
}

const AppDataStore = DataStore();

const ApplicationRoot = () => (
    <Provider store={AppDataStore}>
        <AppRoute history={AppHistory} />
    </Provider>
);

render(<ApplicationRoot />, document.getElementById('root'));