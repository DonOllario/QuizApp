import React, { useState, useEffect } from 'react';
import './QuestionPage.css';
import Questionnaire from './Questionnaire';
import { DefaultButton_blue } from './DefaultButton_blue';
import { DefaultButton_pink } from './DefaultButton_pink';
import { Link } from "react-router-dom";
import CaptureDarkBlue from '../assets/CaptureDarkBlue.PNG';
import './DefaultButton_pink.css';



const API_URL = 'https://opentdb.com/api.php?amount=10&type=multiple';

function QuestionPage() {

    const [questions, setQuestions] = useState([]);
    const [currentIndex, setCurrentIndex] = useState(0);
    const [score, setScore] = useState(0);
    const [showAnswers, setShowAnswers] = useState(false);

    useEffect(() => {
        fetch(API_URL)
            .then((res) => res.json())
            .then((data) => {
                const questions = data.results.map((question) =>
                ({
                    ...question,
                    answers: [
                        question.correct_answer,
                        ...question.incorrect_answers,
                    ].sort(() => Math.random() - 0.5),
                }));
              setQuestions(questions);
              fetch('api/gamerounds', {
                method: 'POST',
                body: JSON.stringify({ numberOfQuestions: 10 }),
                headers: {
                  'Content-Type': 'application/json'
                }
              }).then(response => response.json())
                .then(data => console.log(data));
            });
    }, []);


    const handleAnswer = (answer) => {
        //Check for the answer
        //Show another question
        //Change score if correct

        
        if(!showAnswers) { //prevent double answers
            if(answer === questions[currentIndex].correct_answer){
                setScore(score +1)
            }
        }
        setShowAnswers(true);
    };

    const handleNextQuestion = () => {
        setShowAnswers(false);

        setCurrentIndex(currentIndex + 1);
    }

    return questions.length > 0 ? ( 
        <div>
        {currentIndex >= questions.length ? (
            <div>
                <h1 className="questionInfo">Awesome Adventure! You got: {score}/10 points</h1>
                <div>
                    <img src={CaptureDarkBlue} alt='CaptureDarkBlue' />
                    <div class="display-6 heading-font mb-3">
                        <h1>More daring adventures are yet to come!</h1>
                    </div>
                </div>
                <div>
                    <Link to="/">
                    <DefaultButton_blue value="Return to main menu"/>
                    </Link>
                    <button className="button button_pink" onClick={() => window.location.reload(false)}>Venture Now</button>
                </div>
            </div>
    ) : (
            <Questionnaire 
            data={questions[currentIndex]}
            showAnswers={showAnswers} 
            handleNextQuestion={handleNextQuestion}
            handleAnswer={handleAnswer}/>
        )}
        </div>
    ) : (
        <h1 className="questionInfo" >Laddar data..</h1>
    );
}

export default QuestionPage;