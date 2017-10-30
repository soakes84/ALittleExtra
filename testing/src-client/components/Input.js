import React from "react";
import PropTypes from "prop-types";

const Input = props => {
  const { label, className, type, value, onChange, placeholder, name } = props;
  return (
    <label>
      {label}
      <input
        name={name}
        className={className}
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
