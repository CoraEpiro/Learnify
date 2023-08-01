import PropTypes from "prop-types";

const TitleDivider = ({ title }) => {
  return (
    <div className="flex  items-center space-x-4">
      <div className="flex-1 h-px bg-gray-300"></div>
      <div>{title}</div>
      <div className="flex-1 h-px bg-gray-300"></div>
    </div>
  );
};

TitleDivider.propTypes = { title: PropTypes.element };

export default TitleDivider;
