import React from "react";
import PropTypes from "prop-types";

const Input = props => {
  const { label, className, type, value, onChange, placeholder, name, required } = props;
  return (
    <label>
      {label}
      <span className="input-required">{required ? '*' : ''}</span>
      <input
        name={name}
        className={className + (required && !value.length ? "input-required" : '')}
        value={value}
        type={type}
        onChange={onChange}
        placeholder={placeholder}
      />
    </label>
  );
};
Input.propTypes = {
  label: PropTypes.string.isRequired,
  className: PropTypes.string,
  value: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  type: PropTypes.string,
  name: PropTypes.string.isRequired
};
Input.defaultProps = {
  className: "",
  type: "text"
};

export default Input;
