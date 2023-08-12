import PropTypes from "prop-types";
import { BiErrorAlt } from "react-icons/bi";

const ErrorView = ({ message }) => {
  return (
    <div className={"flex items-center gap-2"}>
      <BiErrorAlt fill={"red"} />
      <p>{message}</p>
    </div>
  );
};

ErrorView.propTypes = {
  message: PropTypes.string,
};

export default ErrorView;
