import React, { Component } from 'react';
import './Frontpage.css';
import { Carousel } from './Carousel';
import { DefaultButton_pink } from './DefaultButton_pink';
import { DefaultButton_blue } from './DefaultButton_blue';
import { Frontpage_logo } from './Frontpage_logo';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import { Highscore } from './Highscore';

export class Frontpage extends Component {

    render() {
        return (
            <Router>
                <div className="background">
                    <Frontpage_logo />
                    <br/>
                    <DefaultButton_pink
                        value="Play"/>
                    <br/>
                    <DefaultButton_blue
                        value="Highscore" />
                    <Carousel/>
                </div>
            </Router>
        );
    }
}