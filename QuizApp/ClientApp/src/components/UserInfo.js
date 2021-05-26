import React, { Component } from 'react';
import './UserInfo.css';
import BluePic from '../assets/KozzQuiz_logo_header_blue.png';

export class UserInfo extends Component {

    render() {
        return (
            <div className="wrapper">
                <div className="user_info">
                    <h2 className="profile_name">Ozzy the Owl</h2>
                    <img className="KozzQuiz_logo_blue" src={BluePic} data-index="1" />
                    <br />
                    <button className="button button_edit_picture" type="button">
                        Edit picture
                            </button>
                    <br />
                    <br />
                    <h3>User info</h3>
                    <p className="user_name">User name: Ozzy the Owl</p>
                    <p className="email_adress">Email Adress: owl@quiz.com</p>
                    <p className="password_userinfo">Password: *******</p>
                    <button className="button button_change_password">Change Password</button>
                </div>
            </div>
        );
    }
}