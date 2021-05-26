import React, { Component } from 'react';
/*import { Route } from 'react-router';*/
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Frontpage } from './components/Frontpage';
import { Highscore } from './components/Highscore';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <Router>
            <Switch>
              <Route exact path='/' component={Frontpage} />
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
