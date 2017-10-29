import React, { Component } from "react";
import {
  withGoogleMap,
  GoogleMap,
  Marker,
  withScriptjs
} from "react-google-maps";

const MapComp = ({ text }) => <div className="">{text}</div>;

const Map = withScriptjs(withGoogleMap(props => {
  return (
       <div className="map-container" style={{width: '200px', height: '200px'}}>
         <GoogleMap
           style={{width: '200px', height: '200px'}}
           defaultZoom={8}
           defaultCenter={{ lat: -34.397, lng: 150.644 }}
         >
           <Marker
             position={{ lat: -34.397, lng: 150.644 }}
           />
         </GoogleMap>
       </div>
     );
}))

export default Map;
