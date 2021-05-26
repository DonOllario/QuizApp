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
            <button type="button" class="header-login-button banner_login align-items-center" data-toggle="modal" data-target="#logInModal"><i class="account-icon fas fa-user-circle fa-2x"></i><span >Log in</span></button>
        </header>
        );
    }
}