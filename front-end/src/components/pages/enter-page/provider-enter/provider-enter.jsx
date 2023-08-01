import PropTypes from "prop-types";

const ProviderEnter = ({ state, title, bgColor, hoverBgColor }) => {
  const providerTitlePrefix = state ? "Sign Up" : "Continue";

  return (
    <div
      className={`w-full min-h-6 p-3 pl-3 pr-5 rounded-lg flex justify-center text-white transition-all duration-150 bg-${bgColor} hover:bg-${hoverBgColor} `}
    >{`${providerTitlePrefix} with ${title}`}</div>
  );
};

ProviderEnter.propTypes = {
  state: PropTypes.string,
  title: PropTypes.string,
  bgColor: PropTypes.string,
  hoverBgColor: PropTypes.string,
};

export default ProviderEnter;
