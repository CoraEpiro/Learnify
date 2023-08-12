import PropTypes from "prop-types";
import { ErrorMessage, useField } from "formik";

const TextAreaInput = ({
  value,
  title,
  placeholder,
  hint,
  maxLength,
  ...props
}) => {
  const [field] = useField(props);

  return (
    <div className={"w-full h-fit flex flex-col justify-between gap-2 "}>
      <div className={"flex gap-3 items-center"}>
        <span className={"text-sm font-medium"}>{title}</span>
        <ErrorMessage
          name={field.name}
          component={"small"}
          className={"text-xs block text-red-700"}
        />
      </div>
      <div className={"flex flex-col gap-1"}>
        <textarea
          {...field}
          {...props}
          value={value}
          placeholder={placeholder}
          maxLength={maxLength}
          className={
            "w-full min-h-[97px]  p-2.5 bg-component-bg text-secondary border-[1px]  border-tz-border  focus:border-tz-border-hover focus:outline-none focus:ring-0  rounded-lg"
          }
        />
        <span className={"text-sm text-dark-text self-end"}>
          {field.value.length}/{maxLength}
        </span>
        <span className={"text-sm text-dark-text"}>{hint}</span>
      </div>
    </div>
  );
};

TextAreaInput.propTypes = {
  value: PropTypes.string,
  title: PropTypes.string,
  hint: PropTypes.string,
  maxLength: PropTypes.number,
  placeholder: PropTypes.string,
};
export default TextAreaInput;
