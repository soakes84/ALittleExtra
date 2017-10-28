import React, { Component } from 'react';

import axios from 'axios';


export default class Home extends Component {
  constructor(){
    super();
    this.state = {
      user: false,
      stores: []
    }
  }
  componentDidMount() {

    axios.get('/api/accounts/stores')
      .then(response => {
        let user = window.localStorage.getItem('user');
        user = JSON.parse(user);
        console.log(user);
        this.setState({ user: user, stores: response.data })
      })
  }

  render(){
    console.log(this.state);
    if(this.state.user === false) {
      return <p>Loading</p>
    } else {
      return (
        <div className="home">
          {this.state.user.name}
          <div className='store-container'>
            {this.state.stores.map(storeData => {
              return <h3 key={storeData.id}>{storeData.email}</h3>
            })}
          </div>
        </div>
      )
    }

  }
}
