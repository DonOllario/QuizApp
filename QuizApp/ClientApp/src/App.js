import React, { Component } from 'react';
/*import { Route } from 'react-router';*/
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Frontpage } from './components/Frontpage';
import { Highscore } from './components/Highscore';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import { Carousel } from './components/Carousel';
import { DefaultButton_pink } from './components/DefaultButton_pink';
import { DefaultButton_blue } from './components/DefaultButton_blue';
import { Frontpage_logo } from './components/Frontpage_logo';
import {HeaderLogin} from './components/HeaderLogin';
import {HeaderProfile} from './components/HeaderProfile';
import QuestionPage from './components/QuestionPage';

import './custom.css';


export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <Router>
            <Switch>
              <Route exact path='/' component={QuestionPage} />
              <Route exact path='/Highscore' component={Highscore} />
             </Switch>
          </Router>

      //<layout>
      //  <route exact path='/' component={Home} />
      //  <route path='/counter' component={Counter} />
      //  <route path='/fetch-data' component={FetchData} />
      //</layout>
    );
  }
}
