import React, { Component } from 'react';
import './Frontpage_logo.css';
import Kozz_logo from '../assets/KozzQuiz_logo_svg.svg';

export class Frontpage_logo extends Component {

    render() {
        return (

            <img className="kozz_logo" src={ Kozz_logo }/> 

        );
    }
}

//Loggan på startsidan importeras och sedan används följande kod för att implementera den:
//<Frontpage_logo/>
