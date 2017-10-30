import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import Login from './Login';
import BankDashboard from './BankDashboard';
import StoreDashboard from './StoreDashboard';
import PageNotFound from '../components/PageNotFound';

export default class App extends Component {

  render(){
    return (
      <div className="App">
        <Switch>
          <Route exact path="/" component={Login}/>
          <Route exact path="/home/foodbank" component={BankDashboard}/>
          <Route exact path="/home/store" component={StoreDashboard}/>
          <Route path="*" component={PageNotFound} />
        </Switch>
      </div>
    )
  }
}
