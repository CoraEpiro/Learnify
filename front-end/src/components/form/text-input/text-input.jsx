import PropTypes from "prop-types";
import { ErrorMessage, useField } from "formik";

const TextInput = ({ title, autoComplete, placeholder, ...props }) => {
  const [field] = useField(props);

  return (
    <div className={"w-full h-fit flex flex-col justify-between gap-2"}>
      <div className={"flex gap-3 items-center"}>
        <span className={"text-sm font-medium"}>{title}</span>
        <ErrorMessage
          name={field.name}
          component={"small"}
          className={"text-xs block text-red-700"}
        />
      </div>
      <div>
        <input
          {...field}
          autoComplete={autoComplete}
          placeholder={placeholder}
          className={
            "w-full bg-white h-9 border border-border-clr rounded-md py-2 pl-3  focus:outline-none hover:border-hover-border-clr focus:outline-accent focus:border-none transition-all duration-75"
          }
          type={"text"}
        />
      </div>
    </div>
  );
};

TextInput.propTypes = {
  title: PropTypes.string,
  placeholder: PropTypes.string,
  autoComplete: PropTypes.string,
};

export default TextInput;
