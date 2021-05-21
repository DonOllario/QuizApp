import React, { Component } from 'react';
import './DefaultButton_pink.css';

export class DefaultButton_pink extends Component {

    render() {
        return (

            <button className="button button_pink">{this.props.value}</button>

        );
    }
}

//Knappen importeras och sedan används följande kod för att implementera den:
//<DefaultButton_pink
//    value="Text here" />
//
//Value ändrar texten i knappen.