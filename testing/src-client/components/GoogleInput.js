import React from "react";
import PlacesAutocomplete, {
  geocodeByAddress,
  getLatLng
} from "react-places-autocomplete";

class GoogleInput extends React.Component {
  constructor(props) {
    super(props);
    this.state = { address: "" };
    this.onChange = address => {
      geocodeByAddress(this.state.address);
      this.setState({ address });
    };
  }

  handleFormSubmit = event => {
    event.preventDefault();

    geocodeByAddress(this.state.address)
      .then(results => getLatLng(results[0]))
      .then(latLng => console.log("Success", latLng))
      .catch(error => console.error("Error", error));
  };

  render() {
    const inputProps = {
      value: this.state.address,
      onChange: this.onChange
    };
    const cssClasses = {
      root: "form-group",
      input: "form-control",
      autocompleteContainer: "autocomplete-container"
    };
    return <PlacesAutocomplete inputProps={inputProps} classNames={cssClasses} />;
  }
}

export default GoogleInput;
