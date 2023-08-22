import PropTypes from "prop-types";

const AccentLightButton = ({ title, click }) => {
  return (
    <button
      onClick={() => click()}
      className={
        " bg-transparent flex items-center text-gray-700  rounded-lg py-2 px-4 hover:text-accent hover:bg-hover-blue-clr hover:underline transition-all duration-150 "
      }
    >
      {title}
    </button>
  );
};

AccentLightButton.propTypes = {
  title: PropTypes.string,
  click: PropTypes.func,
};

export default AccentLightButton;
