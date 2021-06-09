import React, { useState, useEffect } from 'react';
import Rocket from '../assets/Rocket.png';
import {Redirect} from 'react-router-dom';
import './QuestionPage.css';


function AboutToFly () {
    const [counter, setCounter] = useState(3);

    useEffect(() => {
        const timer =
            counter > 0 && setInterval(() => setCounter(counter - 1), 1000);
        return () => clearInterval(timer);
    }, [counter]);
    
    
    
    return counter > 0 ? (
            <>
                <h1 className="aboutToFly">About to fly!</h1>
                <div className="questionInfo mt-1">
                    <img src={Rocket} alt='Rocket' />
                    <div class="display-6 mb-1">
                        <h1>On</h1>
                    </div>
                    <div className="questionInfo display-6 mt-2">{counter}</div>
                </div>
            </>

        ) : (
            <Redirect to="/QuestionPage" />
        );
    
}

export default AboutToFly;