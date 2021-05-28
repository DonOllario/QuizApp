import React, { Component } from 'react';
import { Frontpage } from './components/Frontpage';
import  { Highscore }  from './components/Highscore';
import QuestionPage from './components/QuestionPage';
import Header from './components/Header';
import { UserInfo } from './components/UserInfo';
import FormSignup from './components/form/FormSignup';
import FormLogin from './components/form/FormLogin';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import './custom.css';


export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <Router>
            <Header />
            <Switch>
              <Route exact path='/' component={Frontpage} />
              <Route path='/FormLogin' component={FormLogin}/>
              <Route path='/FormSignup' component={FormSignup}/>
              <Route path='/QuestionPage' component={QuestionPage} />
              <Route path='/Highscore' component={Highscore} />
              <Route path='/UserInfo' component={UserInfo} />
            </Switch>
          </Router>
    );
  }
}
