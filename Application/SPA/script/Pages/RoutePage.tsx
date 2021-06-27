import { ConnectedRouter } from "connected-react-router";
import React from "react";
import { Provider } from "react-redux";
import { Route, Switch } from "react-router";

class AppRoute extends React.Component {
    constructor(props: { history: History<LocationState>}) {
        super(props);

    }
    render() {
        return (
            <ConnectedRouter /*history={this.props.history}*/>
                <Switch>
                    <Route exact /*path={PageRoute.Welcome} component={WelcomePage}*/ />
                </Switch>
            </ConnectedRouter>
        );
    }
}

const ApplicationRoot = () => (
    <Provider>
        <AppRoute history={AppHistory} />
    </Provider>
);