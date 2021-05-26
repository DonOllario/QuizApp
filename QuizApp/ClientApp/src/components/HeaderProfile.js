import React, { Component } from 'react';
import homeImage from '../assets/KozzQuiz_logo_header.png';
import './HeaderLogin.css';

export class HeaderLogin extends Component {
    render(){
        return(
        <header className="header">
            <a href="index.html">
                <img className="header-home-img" src={homeImage} alt="home_logo"></img>
            </a>
            <button className="button banner_login dropbtn"><img style="width: 3rem; margin-right: 1rem;" src="../assets/KozzQuiz_logo_header_pink.png" alt="pink-owl"></img>Profile</button>
        </header>
        );
    }
}

