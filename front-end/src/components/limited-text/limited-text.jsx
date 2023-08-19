import PropTypes from "prop-types";

const LimitedText = ({ text, limit }) => {
  return (
    <div>
      {text.length <= limit ? (
        <div>{text}</div>
      ) : (
        <div>{text.slice(0, limit)}...</div>
      )}
    </div>
  );
};

LimitedText.propTypes = { text: PropTypes.string, limit: PropTypes.number };

export default LimitedText;
