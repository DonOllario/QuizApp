import React, { useState, useEffect } from 'react';
import './QuestionPage.css';
import { Question } from './Question';
import { DefaultButton_pink } from './DefaultButton_pink';
import Questionnaire from './Questionnaire';


const API_URL = 'https://opentdb.com/api.php?amount=10&type=multiple';

function QuestionPage() {

    const [questions, setQuestions] = useState([]);
    const [currentQuestion, setCurrentQuestion] = useState(undefined);

    useEffect(() => {
        fetch(API_URL)
            .then((res) => res.json())
            .then((data) => {
                setQuestions(data.results);
                setCurrentQuestion(data.results[0]);
            });
    }, []);


    const handleAnswer = (answer) => {
        //Check for the answer
        //Show another question
        //Change score if correct
    };


    return questions.length > 0 ? (
        <div>
            <Questionnaire data={questions[0]} handleAnswer={handleAnswer}/>
        </div>
    ) : (
        <h1>Laddar data..</h1>
    );
}

export default QuestionPage;