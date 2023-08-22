import PropTypes from "prop-types";

const PrimaryButton = ({ title, click }) => {
  return (
    <button
      onClick={() => click()}
      className={
        "w-full text-sm font-medium py-2 px-3 rounded-lg hover:bg-hover-bg-clr "
      }
    >
      {title}
    </button>
  );
};

PrimaryButton.propTypes = {
  title: PropTypes.string,
  click: PropTypes.func,
};

export default PrimaryButton;
