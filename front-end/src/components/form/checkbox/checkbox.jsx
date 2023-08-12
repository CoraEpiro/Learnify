import { useField } from "formik";
import PropTypes from "prop-types";
import "./checkbox.css";
import { nanoid } from "nanoid";

const Checkbox = ({ renderTitle, title, ...props }) => {
  const [field] = useField(props);

  const _id = nanoid();
  return (
    <label htmlFor={_id} className="cyberpunk-checkbox-label">
      <input
        {...field}
        checked={field.value}
        id={_id}
        type="checkbox"
        className="cyberpunk-checkbox"
      />
      {renderTitle ? renderTitle : title}
    </label>
  );
};

Checkbox.propTypes = {
  title: PropTypes.string,
  renderTitle: PropTypes.any,
};

export default Checkbox;
