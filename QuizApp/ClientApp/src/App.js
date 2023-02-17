import React, { Component } from 'react';
import { Frontpage } from './components/Frontpage';
import { Highscore } from './components/Highscore';
import QuestionPage from './components/QuestionPage';
import Header from './components/Header';
import { UserInfo } from './components/UserInfo';
import FormSignup from './components/form/FormSignup';
import FormLogin from './components/form/FormLogin';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import AboutToFly from './components/AboutToFly';

import './custom.css';


export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Router>
        <Header />
        <Switch>
          <Route exact path='/QuizApp' component={Frontpage} />
          <Route path='/QuizApp/FormLogin' component={FormLogin} />
          <Route path='/QuizApp/FormSignup' component={FormSignup} />
          <Route path='/QuizApp/AboutToFly' component={AboutToFly} />
          <Route path='/QuizApp/QuestionPage' component={QuestionPage} />
          <Route path='/QuizApp/Highscore' component={Highscore} />
          <Route path='/QuizApp/UserInfo' component={UserInfo} />
          <AuthorizeRoute path='/QuizApp/UserInfo' component={UserInfo} />
          <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
        </Switch>
      </Router>
    );
  }
}
