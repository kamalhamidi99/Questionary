import React, { Component } from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import { TakeQuiz } from './components/TakeQuiz';
import { QuizResult } from './components/QuizResult';
import { Container } from 'reactstrap';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Container>
        <Route exact path='/' component={Home} />
        <Route path='/takequiz' component={TakeQuiz} />
        <Route path='/quizresult' component={QuizResult} />
      </Container>
    );
  }
}
