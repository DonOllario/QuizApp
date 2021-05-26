import React, { Component } from 'react';
import { Frontpage } from './components/Frontpage';
import { Highscore } from './components/Highscore';
import QuestionPage from './components/QuestionPage';
import { HeaderLogin } from './components/HeaderLogin';
import { HeaderProfile } from './components/HeaderProfile';
import { UserInfo } from './components/UserInfo';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import './custom.css';


export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <Router>
            <HeaderProfile />
            {/* <HeaderLogin /> */}
            <Switch>
              <Route exact path='/' component={Frontpage} />
              <Route path='/QuestionPage' component={QuestionPage} />
              <Route path='/Highscore' component={Highscore} />
              <Route path='/UserInfo' component={UserInfo} />
            </Switch>
          </Router>
    );
  }
}
