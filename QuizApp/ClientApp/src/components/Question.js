import React, { Component } from 'react';
import './Question.css';


export class Question extends Component {

    render() {
        return (
                <h1 className="d-flex flex-column justify-content-center align-items-center text-center">{this.props.value}</h1>
        );
    }
}