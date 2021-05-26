import React from 'react';
import './Questionnaire.css';
import { DefaultButton_pink } from './DefaultButton_pink';

const Questionnaire = ( { 
    handleAnswer, data: {question, correct_answer, incorrect_answers},
} ) => {

    const shuffledAnswers = [correct_answer, ...incorrect_answers].sort(() => Math.random() - 0.5);


    return (
    <div>
        <h1 dangerouslySetInnerHTML={{ __html: question }} />
        <br />
        <DefaultButton_pink onClick={() => handleAnswer(shuffledAnswers[0])}
            value={shuffledAnswers[0]} />
        <br />
        <DefaultButton_pink onClick={() => handleAnswer(shuffledAnswers[1])}
            value={shuffledAnswers[1]} />
        <br />
        <DefaultButton_pink onClick={() => handleAnswer(shuffledAnswers[2])}
            value={shuffledAnswers[2]} />
        <br />
        <DefaultButton_pink onClick={() => handleAnswer(shuffledAnswers[3])}
            value={shuffledAnswers[3]} />

            
    </div>
)};

export default Questionnaire;