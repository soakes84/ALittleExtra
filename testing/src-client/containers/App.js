import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import Login from './Login';


export default class App extends Component {

  render(){
    return (
      <div className="App">
        <Switch>

          <Route exact path="/" component={Login}/>
        </Switch>
      </div>
    )
  }
}
