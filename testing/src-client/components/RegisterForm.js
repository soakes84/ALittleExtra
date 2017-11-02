import React, { Component } from 'react';

import Input from './Input';

import GoogleInput from './GoogleInput';
import ModalWrapper from './ModalWrapper';


export default class RegisterForm extends Component {
  state = {
    email: '',
    password: '',
    isStore: false,
    location: '',
    userName: ''
  }
  _onChange = (evt) => {
    const { name, value } = evt.target;
    evt.preventDefault();
    this.setState({[name] : value});
  }
  render(){
    const { showModal } = this.props
    const { password, email, userName } = this.props
    return(
      <ModalWrapper showModal={showModal} header='Register' toggleModal={this.props.toggleModal}>
        <div className="register-form">
          <Input
            key="email-125"
            onChange={this._onChange}
            label="Email"
            type="email"
            name="email"
            value={email}
            placeholder="Email"
          />
          <Input
            key="pas-123"
            placeholder="Password"
            onChange={this._onChange}
            label="Password"
            name="password"
            type="password"
            value={password}
          />
          <Input
            key="str-123"
            placeholder="Store Name"
            onChange={this._onChange}
            label="Store Name"
            name="userName"
            value={userName}
          />
          <GoogleInput />
        </div>
      </ModalWrapper>

    )
  }
}
