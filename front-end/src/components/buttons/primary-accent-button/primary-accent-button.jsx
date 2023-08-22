import PropTypes from "prop-types";

const PrimaryAccentButton = ({ title, click }) => {
  return (
    <button
      onClick={() => click()}
      className={
        "w-full text-sm text-gray-200 font-medium py-2 px-4 rounded-md bg-accent hover:bg-accent-dark transition-all duration-70"
      }
    >
      {title}
    </button>
  );
};

PrimaryAccentButton.propTypes = {
  title: PropTypes.string,
  click: PropTypes.func,
};

export default PrimaryAccentButton;
