import PropTypes from "prop-types";
import { ErrorMessage, useField } from "formik";

const TextInput = ({ value, title, autoComplete, placeholder, ...props }) => {
  const [field] = useField(props);

  return (
    <div className={"w-full h-fit flex flex-col justify-between gap-2"}>
      <div>
        <span className={"text-sm font-medium"}>{title}</span>
      </div>
      <div>
        <input
          {...field}
          autoComplete={autoComplete}
          value={value}
          placeholder={placeholder}
          className={
            "w-full bg-white h-9 placeholder-gray-900 border border-border-clr rounded-md py-2 pl-3  focus:outline-none hover:border-hover-border-clr focus:outline-accent focus:border-none transition-all duration-75"
          }
          type={"text"}
        />
        <ErrorMessage
          name={field.name}
          component={"small"}
          className={"text-xs block mt-2 text-tz-red-text"}
        />
      </div>
    </div>
  );
};

TextInput.propTypes = {
  value: PropTypes.string,
  title: PropTypes.string,
  placeholder: PropTypes.string,
  autoComplete: PropTypes.string,
};

export default TextInput;
