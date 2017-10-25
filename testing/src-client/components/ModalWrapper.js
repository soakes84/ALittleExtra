import React from "react";

const ModalWrapper = props => {
  const { showModal, className, children, toggleModal } = props;
  return showModal ? (
    <div className="modal">
      <div className="modal-content">
        {children}
        <button className="close-button" onClick={toggleModal} type="button">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>

    </div>
  ) : null;
};

export default ModalWrapper;
