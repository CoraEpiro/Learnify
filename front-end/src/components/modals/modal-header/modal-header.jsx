import PropTypes from "prop-types";
import ModalCloseButton from "../modal-close-button/index.js";

const ModalHeader = ({ title }) => {
  return (
    <div
      className={
        "flex items-center justify-between border-b border-border-clr p-1 px-6 py-3 bg-white rounded-t-md"
      }
    >
      <span className={"font-bold text-xl"}>{title}</span>
      <ModalCloseButton />
    </div>
  );
};

ModalHeader.propTypes = {
  title: PropTypes.string,
};

export default ModalHeader;
