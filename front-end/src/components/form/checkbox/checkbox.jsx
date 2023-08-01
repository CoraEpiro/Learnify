import { useField } from "formik";
import PropTypes from "prop-types";
import "./checkbox.css";

// eslint-disable-next-line no-unused-vars
const Checkbox = ({ title, ...props }) => {
  const [field] = useField(props);

  return (
    <label htmlFor="checkbox" className="cyberpunk-checkbox-label">
      <input
        {...field}
        checked={field.value}
        id="checkbox"
        type="checkbox"
        className="cyberpunk-checkbox"
      />
      {title}
    </label>
  );
};

Checkbox.propTypes = {
  checked: PropTypes.bool,
  title: PropTypes.string,
};

export default Checkbox;
