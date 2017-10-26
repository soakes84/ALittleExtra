import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import Login from './Login';
import Home from './Home';

export default class App extends Component {

  render(){
    return (
      <div className="App">
        <Switch>
          <Route exact path="/" component={Login}/>
          <Route exact path="/home" component={Home}/>
        </Switch>
      </div>
    )
  }
}
