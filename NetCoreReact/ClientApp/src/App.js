import SampleComponent from './components/SampleComponent';
import NavigationBar from './components/NavigationBar';
import { Route, Switch } from 'react-router-dom';
import Logout from './components/Logout';
import React, { Component } from 'react';
import Login from './components/Login';
import Home from './components/Home';

const NotFound = () => (
	<div className="form-horizontal">
		<h2>Not Found!</h2>

		<br />

		<p>The page you have requested does not exist. :(</p>
	</div>
)

class App extends Component {
  static displayName = "Opportunity Hack 2019";

	render () {
		return (
			<div>
				<NavigationBar />
				<main role="main" className="container">
					<Switch>
						<Route exact path='/' component={(props) => (<Home {...props} />)} />
						<Route path='/sample-route' component={(props) => (<SampleComponent {...props} />)} />
						<Route path='/login' component={(props) => (<Login {...props} />)} />
						<Route path='/logout' component={(props) => (<Logout {...props} />)} />
						<Route component={NotFound} />
					</Switch>
				</main>
			</div>
		);
	}
};

export default App;