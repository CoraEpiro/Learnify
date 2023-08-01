import { ErrorMessage, useField } from "formik";
import PropTypes from "prop-types";

const PasswordInput = ({
  value,
  title,
  autoComplete,
  placeholder,
  ...props
}) => {
  const [field] = useField(props);

  return (
    <div className={"w-full h-fit flex flex-col justify-between gap-2"}>
      <div>
        <span className={"text-sm font-medium"}>{title}</span>
      </div>
      <div>
        <input
          {...field}
          value={value}
          placeholder={placeholder}
          autoComplete={autoComplete}
          className={
            "w-full h-9 bg-white placeholder-gray-900 border border-border-clr rounded-md py-2 pl-3  focus:outline-none hover:border-hover-border-clr focus:outline-accent focus:border-none transition-all duration-75"
          }
          type={"password"}
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
PasswordInput.propTypes = {
  value: PropTypes.string,
  title: PropTypes.string,
  placeholder: PropTypes.string,
  autoComplete: PropTypes.string,
};

export default PasswordInput;
