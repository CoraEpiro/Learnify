import PropTypes from "prop-types";

const PrimaryButton = ({ title }) => {
  return (
    <button
      className={
        "text-sm font-medium py-2 px-3 rounded-lg hover:bg-hover-bg-clr "
      }
    >
      {title}
    </button>
  );
};

PrimaryButton.propTypes = {
  title: PropTypes.string,
};

export default PrimaryButton;
