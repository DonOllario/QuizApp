import React, { Component } from 'react';
import './DefaultButton_blue.css';

export class DefaultButton_blue extends Component {

    render() {
        return (

            <button
                className="button button_blue">{this.props.value}</button>

        );
    }
}

//Knappen importeras och sedan används följande kod för att implementera den:
//<DefaultButton_blue
//    value="Text here" />
//
//Value ändrar texten i knappen.