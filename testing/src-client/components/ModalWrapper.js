import React from "react";

const ModalWrapper = props => {
  const { showModal, className, children, toggleModal, header } = props;
  return showModal ? (
    <div className="modal">
      <div className="modal-content">
        <div className="modal-header">
          <h3>{header}</h3>
        </div>
        {children}
        <button className="close-button" onClick={toggleModal} type="button">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
    </div>
  ) : null;
};

export default ModalWrapper;
