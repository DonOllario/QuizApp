import React, { useState, useEffect } from 'react';
import './QuestionPage.css';
import Questionnaire from './Questionnaire';


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
        <h1 className="questionInfo">Game finished! Your score was: {score}</h1>
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