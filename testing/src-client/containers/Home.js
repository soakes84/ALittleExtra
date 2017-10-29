import React, { Component } from 'react';

import axios from 'axios';
import { API_KEY } from '../secrets';
import Map from '../components/GoogleMap';

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
          <Map
            isMarkerShown
            googleMapURL={`https://maps.googleapis.com/maps/api/js?key=${API_KEY}&v=3.exp&libraries=geometry,drawing,places`}
            loadingElement={<div style={{ height: `100%` }} />}
            containerElement={<div style={{ height: `400px` }} />}
            mapElement={<div style={{ height: `100%` }} />}
          />
        </div>
      )
    }

  }
}
