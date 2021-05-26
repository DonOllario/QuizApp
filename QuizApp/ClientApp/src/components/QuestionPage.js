import React, { useState, useEffect } from 'react';
import './QuestionPage.css';
import { Question } from './Question';
import { DefaultButton_pink } from './DefaultButton_pink';


const API_URL = 'https://opentdb.com/api.php?amount=10&type=multiple';

function QuestionPage() {

    const [questions, setQuestions] = useState([]);

    useEffect(() => {
        fetch(API_URL)
            .then((res) => res.json())
            .then((data) => {
                setQuestions(data.results);
            });
    }, []);

    return questions.length > 0 ? (
        <div>
            <div>
            <h1 dangerouslySetInnerHTML={{ __html: questions[5].question}}/>
                <br />
                <DefaultButton_pink
                    value={questions[0].correct_answer} />
                <br />
                <DefaultButton_pink
                    value={questions[0].incorrect_answers[0]} />
                <br />
                <DefaultButton_pink
                    value={questions[0].incorrect_answers[1]} />
                <br />
                <DefaultButton_pink
                    value={questions[0].incorrect_answers[2]} />
            </div>
        </div>
    ) : (
        <h1>Laddar data..</h1>
    );
}

export default QuestionPage;