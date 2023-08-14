import PropTypes from "prop-types";
import classNames from "classnames";

const FilterOption = ({ title, isActive }) => {
  return (
    <button
      className={classNames({
        "py-2 px-3 rounded-lg hover:bg-white hover:text-accent": true,
        "font-bold": isActive,
      })}
    >
      {title}
    </button>
  );
};

FilterOption.propTypes = { title: PropTypes.string, isActive: PropTypes.bool };

export default FilterOption;
