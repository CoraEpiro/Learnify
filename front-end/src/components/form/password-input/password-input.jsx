import PropTypes from "prop-types";
import { BsEye, BsEyeSlash } from "react-icons/bs";
import KeyWarning from "../../key-warning/index.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import PasswordCondition from "../password-condition/index.js";
import { ErrorMessage, useField } from "formik";
import { useState } from "react";

const PasswordInput = ({
  value,
  title,
  autoComplete,
  placeholder,
  isNewPassword,
  ...props
}) => {
  const [animationParent] = useAutoAnimate();

  const [field, meta] = useField(props);
  const [isPasswordVisible, setIsPasswordVisible] = useState(false);
  const [isCapsLockOn, setIsCapsLockOn] = useState(false);
  const [isNumLockOn, setIsNumLockOn] = useState(false);

  const handleKeyUp = (e) => {
    const capsLockIsOn = e.getModifierState("CapsLock");
    const numLockIsOn = e.getModifierState("NumLock");
    setIsCapsLockOn(capsLockIsOn);
    setIsNumLockOn(numLockIsOn);
  };

  return (
    <div
      className={"w-full h-fit  flex flex-col justify-between gap-2"}
      ref={animationParent}
    >
      <div className={"flex gap-3 items-center"}>
        <span className={"text-sm font-medium"}>{title}</span>
        <ErrorMessage
          name={field.name}
          component={"small"}
          className={"text-xs block text-red-700"}
        />
      </div>
      <div className={"flex flex-col gap-3"} ref={animationParent}>
        <div className={"relative"}>
          <input
            {...field}
            onKeyUp={handleKeyUp}
            value={value}
            placeholder={placeholder}
            autoComplete={autoComplete}
            className={
              "w-full h-9 bg-white placeholder-gray-900 border border-border-clr rounded-md py-2 pl-3  focus:outline-none hover:border-hover-border-clr focus:outline-accent focus:border-none transition-all duration-75"
            }
            type={isPasswordVisible ? "text" : "password"}
          />
          <button
            className="absolute inset-y-0 right-0 flex items-center px-4 text-gray-600"
            onClick={() => setIsPasswordVisible(!isPasswordVisible)}
          >
            {isPasswordVisible ? <BsEye /> : <BsEyeSlash />}
          </button>
        </div>
        {/*Key Notify*/}
        <div className={"flex flex-col gap-2"} ref={animationParent}>
          {isCapsLockOn && <KeyWarning name={"CapsLock"} />}
          {isNumLockOn && <KeyWarning name={"NumLock"} />}
        </div>
        {/*Password Conditions*/}
        {isNewPassword && meta.touched && (
          <div className={"flex flex-col gap-2"}>
            <PasswordCondition
              value={field.value}
              pattern={"^.{9,}$"}
              title={"At least 8 characters long"}
            />
            <PasswordCondition
              value={field.value}
              pattern={"(?=.*[A-Z])"}
              title={"Contain at least one uppercase letter (A-Z)"}
            />
            <PasswordCondition
              value={field.value}
              pattern={"(?=.*[a-z])"}
              title={"Contain at least one lowercase letter (a-z)"}
            />
            <PasswordCondition
              value={field.value}
              pattern={"(?=.*\\d)"}
              title={"Contain at least one digit (0-9)"}
            />
            <PasswordCondition
              value={field.value}
              pattern={"(?=.*[!@#\\$%^&*()\\-_=+{};:'\",<.>/?\\\\\\[\\]|~])"}
              title={"Contain at least one special character"}
            />
          </div>
        )}
      </div>
    </div>
  );
};
PasswordInput.propTypes = {
  value: PropTypes.string,
  title: PropTypes.string,
  placeholder: PropTypes.string,
  autoComplete: PropTypes.string,
  isNewPassword: PropTypes.bool,
};

export default PasswordInput;
