import React, { Component } from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import Login from './containers/Login';
import './styles/styles.scss';




render(<Login/>, document.querySelector('#app-container'))
