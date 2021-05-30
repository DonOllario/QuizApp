import React, { Component } from 'react';
import homeImage from '../assets/KozzQuiz_logo_header.png';
import './HeaderLogin.css';
import { Link } from "react-router-dom";

export class HeaderLogin extends Component {
    render(){
        return(
        <header className="header">
            <Link to="/">
                <img className="header-home-img" src={homeImage} alt="home_logo"></img>
            </Link>
            <Link to="/FormLogin">
                <button type="button" class="header-login-button align-items-center" data-toggle="modal" data-target="#logInModal"><i class="account-icon fas fa-user-circle fa-2x"></i><span >Log in</span></button>
            </Link>
        </header>
        );
    }
}