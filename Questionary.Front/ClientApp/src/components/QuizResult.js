import React, { useState, useEffect } from 'react';
import { useHistory } from "react-router-dom";
import { getData, putData } from '../Base'

export function QuizResult(props) {
  const history = useHistory();

  const data = props.location.state;

  const [isEnded, setIsEnded] = useState(false)
  const [result, setResult] = useState(null)

  useEffect(() => {
    const params = new FormData();
    params.append('id', data.quizId);
    putData('/Quiz', params, (response) => {
      setIsEnded(true)
    })
  }, [data.quizId])

  useEffect(() => {
    if (isEnded === false) {
      return
    }
    getData('/Quiz?id=' + data.quizId, null, (response) => {
      setResult(response.data)
    })
  }, [isEnded])

  const onGoBack = () => {
    history.push("/");
  }

  return (
    <div className="card mt-4">
      <div className="card-header">
        <span>Here is you result, {result?.name}:</span>
      </div>
      <div className="card-body">
        <ul className="list-group">
          <li className="list-group-item">Started date: {result?.dateStarted}</li>
          <li className="list-group-item">Ended date: {result?.dateEnded}</li>
          <li className="list-group-item">Total of currect answers: {result?.result.filter(x => x.isCorrect === true).length}</li>
          <li className="list-group-item">Total of question: {result?.result.length}</li>
        </ul>
      </div>
      <div className="card-footer">
        <button className="btn btn-info text-white float-right" onClick={onGoBack}>Retake it!</button>
      </div>
    </div>
  );
}
