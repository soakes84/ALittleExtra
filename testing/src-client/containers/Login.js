import React, { Component } from "react";
import { StaggeredMotion, spring } from "react-motion";
import axios from 'axios';
import ModalWrapper from "../components/ModalWrapper";

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
  _onEmailChange = (evt) => {
    this.setState({ email: evt.target.value})
  }

  _onPasswordChange = (evt) => {
    this.setState({password: evt.target.value})
  }
  _handleSubmit = (evt) => {
    evt.preventDefault();
    // 'localhost:8080/login'
    axios.post('/api/accounts/login', {
      email: this.state.email,
      password: this.state.password
    })
    .then(response => {
      window.localStorage.setItem('user', JSON.stringify(response.data))
      this.props.history.push('/home')
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
                        <label>Email
                          <input value={this.state.email} type="email" onChange={this._onEmailChange} placeholder="Email"/>
                        </label>
                      </div>
                      <div className="medium-6 cell">
                        <label>Password
                          <input value={this.state.password} type="password" onChange={this._onPasswordChange} placeholder="Password"/>
                        </label>
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
