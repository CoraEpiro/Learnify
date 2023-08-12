import PropTypes from "prop-types";
import { FcInfo } from "react-icons/fc";

const KeyWarning = ({ name }) => {
  return (
    <div className={"flex items-center gap-2"}>
      <FcInfo />
      <p className={"text-sm"}>
        <span className={"font-bold"}>{name}</span> is on
      </p>
    </div>
  );
};

KeyWarning.propTypes = {
  name: PropTypes.string,
};

export default KeyWarning;
