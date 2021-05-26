import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Carousel } from './components/Carousel';
import { DefaultButton_pink } from './components/DefaultButton_pink';
import { DefaultButton_blue } from './components/DefaultButton_blue';
import { Frontpage_logo } from './components/Frontpage_logo';
//import { Highscores } from './components/Highscores';
import { Link } from 'react-router-dom';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <div>

              <Frontpage_logo/>
              <br/>
                  <DefaultButton_pink
                      value="Test1" />
              <br />
                      <DefaultButton_blue
                      value="Test2"/>
              <br/>
              <Carousel />
              {/*<Highscores />*/}

          </div>

      //<layout>
      //  <route exact path='/' component={Home} />
      //  <route path='/counter' component={Counter} />
      //  <route path='/fetch-data' component={FetchData} />
      //</layout>
    );
  }
}
