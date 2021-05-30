import React, { Component } from 'react';
import './Score.css';
import BluePic from '../assets/KozzQuiz_logo_header_blue.png';

export class Score extends Component {

    render() {
        return (

            <div className="score">
                <h2 className="profile_name">Ozzy the Owl</h2>
                <img className="KozzQuiz_logo_blue" src={BluePic} data-index="1" />
                <br />
                <h3>Score</h3>
                <ol className="listPoints" type="1">
                    <li>5000 points</li>
                    <li>4000 points</li>
                    <li>3000 points</li>
                    <li>2000 points</li>
                </ol>
            </div>
        );
    }

}