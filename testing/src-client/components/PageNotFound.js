import React from 'react';


const PageNotFound = (props) => {
  return (
    <div className="404">
      <h1>404 page not found</h1>
      <h3>Sorry about your luck</h3>
      <button className="button" onClick={props.history.goBack}>Take me back!</button>
    </div>
  )
}

export default PageNotFound;
