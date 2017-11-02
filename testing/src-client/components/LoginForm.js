import React, { Component } from "react";

import Input from "./Input";

export default class LoginForm extends Component {
  constructor() {
    super();
    this.state = {
      email: "",
      password: ""
    };
  }

  _onChange = evt => {
    console.log(evt.target.value);
    const { value, name } = evt.target;
    this.setState({ [name]: value });
  };
  _handleSubmit = evt => {
    evt.preventDefault();
    // 'localhost:8080/login'
    axios
      .post("/api/accounts/login", {
        email: this.state.email,
        password: this.state.password
      })
      .then(response => {
        const user = response.data;
        window.localStorage.setItem("user", JSON.stringify(user));
        if (user.isStore) {
          this.props.history.push("/home/store");
        } else {
          this.props.history.push("/home/foodbank");
        }
      })
      .catch(response => {
        console.log("invalid email");
      });
  };

  render() {
    return (
      <form onSubmit={this._handleSubmit} className="login-form">
        <div className="grid-container">
          <div className="grid-x grid-padding-x">
            <div className="medium-6 cell">
              <Input
                key="email-123"
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
                key="pas-123"
                placeholder="Password"
                onChange={this._onChange}
                label="Password"
                name="password"
                type="password"
                value={this.state.password}
              />
            </div>
          </div>
        </div>
        <button className="button button-round" type="submit">
          Login
        </button>
      </form>
    );
  }
}
