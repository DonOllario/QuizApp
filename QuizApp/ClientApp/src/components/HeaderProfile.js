import React, { Component } from 'react';
import homeImage from '../assets/KozzQuiz_logo_header.png';
import profileImage from '../assets/KozzQuiz_logo_header_blue.png'
import './HeaderProfile.css';

export class HeaderProfile extends Component {
    render(){
        return(
        <header className="header">
            <a href="index.html">
                <img className="header-home-img" src={homeImage} alt="home_logo"></img>
            </a>
            <button type="button" className="header-login header-login-button dropbtn"><img className="profile-img" src={profileImage} alt="blue-owl"></img>Profile</button>
        </header>
        );
    }
}