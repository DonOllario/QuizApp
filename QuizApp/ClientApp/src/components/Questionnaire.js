import React from 'react';
import { Frontpage_logo } from './Frontpage_logo';
import './Questionnaire.css';
import './DefaultButton_pink.css';

const Questionnaire = ( { 
    showAnswers,
    handleAnswer,
    handleNextQuestion,
    data: {question, correct_answer, answers},
} ) => {

    return (
    <div>
        <div className="quiz-div d-flex flex-column justify-content-center align-items-center">
        <Frontpage_logo />
        <div>
        <h1 dangerouslySetInnerHTML={{ __html: question }} />
        </div>

        <div >
        {answers.map((answer) => {
            const rightOrWrongColor = showAnswers ? answer == correct_answer ? 
            'bg-green' 
            : 'bg-red' 
            : 'button_pink';

            return (
            <button
            
                className = {`${rightOrWrongColor} button d-flex flex-column justify-content-center align-items-center `}
                onClick={() => handleAnswer (answer)}
                dangerouslySetInnerHTML={{ __html: answer }}/>
        )})}
        </div>
        {showAnswers && (
        <button 
        onClick={handleNextQuestion}
        className="btn-next">
            Next Question
        </button>
        )}
        </div> 
    </div>
    
)};


export default Questionnaire;