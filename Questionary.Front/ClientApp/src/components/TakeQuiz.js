import React, { useState, useEffect } from 'react';
import { useHistory } from "react-router-dom";
import { getData, postData } from '../Base'

export function TakeQuiz(props) {
    const history = useHistory();

    const data = props.location.state;

    const [questions, setQuestions] = useState([])
    const [currentQuestion, setCurrentQuestion] = useState()
    const [questionIndex, setQuestionIndex] = useState(-1)
    const [paging, setPaging] = useState('')
    const [answers, setAnswers] = useState([])

    useEffect(() => {
        const params = new URLSearchParams();
        params.append('group', '0'); // -> json!
        getData('/Question', params, (response) => {
            setQuestions(response.data)
            setQuestionIndex(0)
        })
    }, [])

    useEffect(() => {
        if (questionIndex === -1) {
            return
        }
        setCurrentQuestion(questions[questionIndex])
        setPaging(`${(questionIndex + 1)} of ${questions.length}`)
    }, [questionIndex])

    const onNext = () => {
        if (answers.length === 0) {
            alert('Please answer the question.')
            return
        }
        const params = new FormData();
        params.append('quizId', data.quizId);
        params.append('answerIds', answers);
        postData('/QuizAnswer', params, (response) => {
            if (questions.length <= (questionIndex + 1)) {
                history.push("/quizresult", { quizId: data.quizId });
                return;
            }
            setQuestionIndex((questionIndex + 1))
            setPaging(`${(questionIndex + 1)} of ${questions.length}`)
            setAnswers([])
        })
    }

    const onAnswerRadio = event => {
        setAnswers([event.target.value])
        setUpdate(event.target.value)
    }

    const [update, setUpdate] = useState(0)

    const onAnswerCheckBox = event => {
        var checked = event.target.checked;
        const value = event.target.value;
        if (checked === true) {
            if (answers.includes(value) === false) {
                answers.push(value)
            }
        } else {
            const index = answers.indexOf(value);
            if (index > -1) {
                answers.splice(index, 1);
            }
        }
        setAnswers(answers)
        setUpdate(event.target.value)
    }

    return (
        <>
            <div className="card mt-4">
                <div className="card-header">
                    <span>Please answer the questions, {data.userName}!</span>
                </div>
            </div>
            <div className="card mt-4">
                <div className="card-header">
                    <span>{currentQuestion?.question}</span>
                </div>
                <ul className="list-group">
                    {
                        currentQuestion?.choices.map((item, index) => (
                            <li className="list-group-item" key={index}>
                                {currentQuestion.type === 'SingleAnswer'
                                    ? (<input type="radio" className="mr-2" onChange={onAnswerRadio} value={item.id} name="answer"
                                        checked={answers.includes(`${item.id}`)} />)
                                    : (<input type="checkbox" className="mr-2" onChange={onAnswerCheckBox} value={item.id} name="answer"
                                        checked={answers.includes(`${item.id}`)} />)}
                                {item.choice}
                            </li>
                        ))
                    }
                </ul>
                <div className="card-footer">
                    <span>{paging}</span>
                    <button className="btn btn-info text-white float-right" onClick={onNext}>Next</button>
                </div>
            </div>
        </>
    );
}
