import React, { Component } from 'react';
import './Frontpage.css';
import { Carousel } from './Carousel';
import { DefaultButton_pink } from './DefaultButton_pink';
import { DefaultButton_blue } from './DefaultButton_blue';
import { Frontpage_logo } from './Frontpage_logo';
import { Link } from "react-router-dom";
import { Highscore } from './Highscore';

export class Frontpage extends Component {

    render() {
        return (
            <div className="background">
                <Frontpage_logo />
                <br />
                <Link to="/QuestionPage">
                <DefaultButton_pink
                    value="Play" />
                </Link>
                <br />
                <Link to="/Highscore">
                    <DefaultButton_blue
                        value="Highscore" />
                </Link>
                <Carousel />
            </div>
        );
    }
}