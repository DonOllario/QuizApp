import React, { useState, useEffect } from 'react';
import './QuestionPage.css';
import Questionnaire from './Questionnaire';
import { DefaultButton_blue } from './DefaultButton_blue';
import { Link } from "react-router-dom";
import BlueIdea from '../assets/BlueIdea.png';
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
                <h1 className="questionInfo mb-2">Awesome Adventure! You got: {score} out of 10 points!</h1>
                <div className="lightBulb">
                    <img className="lightBulbSize mb-2" src={BlueIdea} alt='BlueIdea' />
                    <div class="display-6">
                        <h1 className="mt-2">More daring adventures are yet to come!</h1>
                        <img 
                        src="https://video-public.canva.com/VAEJyoG5qTU/v/664bb31503.gif"
                        class="bookAnimation-size mx-auto mb-1"
                        alt="book">
                        </img>
                    </div>
                </div>
                <div className="d-flex justify-content-center"> 
                    <Link to="/QuizApp">
                    <DefaultButton_blue value="Return to main menu" className="mr-3"/>
                    </Link>
                    <button className="button button_pink ml-3" onClick={() => window.location.reload(false)}>Venture Now</button>
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
        <h1 className="questionInfo" >Taking off...</h1>
    );
}

export default QuestionPage;

 
