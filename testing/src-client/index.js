import React, { Component } from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import { HashRouter } from "react-router-dom";
import App from "./containers/App";
import "./styles/styles.scss";

render(
  <Provider>
    <HashRouter>
      <App />
    </HashRouter>
  </Provider>,
  document.querySelector("#app-container")
);
