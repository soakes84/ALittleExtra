import React, { Component } from "react";
import { StaggeredMotion, spring } from "react-motion";
import axios from 'axios';
import ModalWrapper from "../components/ModalWrapper";

import Input from '../components/Input';

const colors = ["#39f1c4", "#31ddb3", "#2ccba4"];

const Box = props => {
  const styles = {
    flexBasis: `${props.width}%`,
    background: `${props.bgColor}`
  };
  return <div className="box" style={styles} />;
};
// const LoginWrapper = props => {
//   return (
//     <div className="columns small-12 main-bg grid-x align-center text-center">
//       <div className="header-content columns text-center">
//         <h1 className="logo">a.LittlExtra</h1>
//         <p>Connecting Nonprofits with Local food Sources</p>
//         <button className="button button-round" onClick={props.toggleModal}>Login</button>
//       </div>
//     </div>
//   );
// };

export default class Login extends Component {
  constructor(){
    super();
    this.state = {
      email: '',
      password: ''
    }
  }
  _onChange = (evt) => {
    console.log(evt.target.value);
    const { value, name } = evt.target;
    this.setState({[name] : value})
  }
  _handleSubmit = (evt) => {
    evt.preventDefault();
    // 'localhost:8080/login'
    axios.post('/api/accounts/login', {
      email: this.state.email,
      password: this.state.password
    })
    .then(response => {
      const user = response.data;
      window.localStorage.setItem('user', JSON.stringify(user))
      if(user.isStore) {
        this.props.history.push('/home/store')

      } else {
        this.props.history.push('/home/foodbank')
      }
    })
    .catch(response => {
      console.log('invalid email');
    })
  }

  render() {
    const { showModal } = this.state;
    return (
      <StaggeredMotion
        defaultStyles={[{ width: 100 }, { width: 100 }, { width: 100 }]}
        styles={prevStyles => [
          { width: spring(0) },
          { width: spring(prevStyles[0].width) },
          { width: spring(prevStyles[1].width) }
        ]}
      >
        {styles => (
          <div
            className="grid-y"
            style={{
              width: "100vw",
              height: "100vh",
              flexFlow: "nowrap",
              flexDirection: "column"
            }}
          >
            <Box bgColor={colors[0]} width={styles[0].width} />
            <Box bgColor={colors[1]} width={styles[1].width} />
            <Box bgColor={colors[2]} width={styles[2].width} />
            <div className="columns small-12 main-bg grid-x align-center text-center">
              <div className="header-content columns text-center">
                <h1 className="logo">a.LittlExtra</h1>
                <p>Connecting Nonprofits with Local food Sources</p>
                <form onSubmit={this._handleSubmit}>
                  <div className="grid-container">
                    <div className="grid-x grid-padding-x">
                      <div className="medium-6 cell">
                        <Input
                          onChange={this._onChange}
                          label="Email"
                          type="email"
                          name="email"
                          value={this.state.email}
                          placeholder="Email"
                        />
                      </div>
                      <div className="medium-6 cell">
                        <Input
                          placeholder="Password"
                          onChange={this._onChange}
                          label="Password"
                          name="email"
                          type="password"
                          value={this.state.password}
                        />
                      </div>
                    </div>
                  </div>
                  <button className="button button-round">Login</button>
                </form>
              </div>
            </div>
          </div>
        )}
      </StaggeredMotion>
    );
  }
}
