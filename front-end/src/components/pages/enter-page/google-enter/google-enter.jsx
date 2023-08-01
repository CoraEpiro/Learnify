import PropTypes from "prop-types";
import { ImGoogle3 } from "react-icons/im";

const GoogleEnter = ({ state }) => {
  const providerTitlePrefix = state ? "Sign Up" : "Continue";

  return (
    <button
      className={`w-full min-h-6 p-3 pl-3 pr-5 rounded-lg flex justify-center items-center gap-2 text-white font-medium transition-all duration-150 bg-green-600 hover:bg-green-700 `}
    >
      <ImGoogle3 size={24} />
      {`${providerTitlePrefix} with Google`}
    </button>
  );
};
GoogleEnter.propTypes = {
  state: PropTypes.object,
};

export default GoogleEnter;
