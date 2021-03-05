import React, { useState, useEffect } from 'react';

import { useHistory } from "react-router-dom";
import { postData } from '../Base'


export function Home() {
  const history = useHistory();

  const [userName, setUserName] = useState('')
  const [quizId, setQuizId] = useState(0)

  const onStart = async () => {
    if (userName === "") {
      alert("Please enter your name.")
      return;
    }
    const params = new FormData()
    params.append('name', userName)
    postData('/Quiz', params, (responce) => {
      setQuizId(responce.data.quizId)
    })
  }

  useEffect(() => {
    if (quizId === 0) {
      return
    }
    history.push("/takequiz", { quizId, userName });
  }, [quizId])

  return (
    <div className="card mt-4">
      <div className="card-header">
        <span>Online Quiz</span>
      </div>
      <div className="card-body">
        <div className="form-row align-items-center">
          <div className="col-sm-auto my-1">
            <div className="input-group">
              <div className="input-group-prepend">
                <div className="input-group-text">Please enter your name</div>
              </div>
              <input type="text" className="form-control" id="FieldName" onChange={x => setUserName(x.target.value)} value={userName} />
            </div>
          </div>
          <div className="col-auto my-1">
            <button onClick={onStart} type="button" className="btn btn-primary">Start</button>
          </div>
        </div>
      </div>
    </div>
  );
}
