import ResetPasswordHeader from "../reset-password-header/index.js";
import { Form, Formik } from "formik";
import PasswordInput from "../../form/password-input/index.js";
import { CgPassword } from "react-icons/cg";
import PropTypes from "prop-types";
import { ResetPasswordNewPasswordFormSchema } from "../../../validation/Schemas/ResetPasswordNewPasswordFormSchema.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import { useState } from "react";
import ErrorView from "../../error-view/index.js";

const ResetPasswordNewPasswordStep = ({ onStepForward }) => {
  const [animationParent] = useAutoAnimate();

  const [passwordsAreMatched, setPasswordAreMatched] = useState(true);

  return (
    <div className={"flex flex-col gap-4"} ref={animationParent}>
      <ResetPasswordHeader
        title={"Set new password"}
        description={"Must be at least 8 characters"}
        icon={<CgPassword size={30} className={"reset-password-header-icon"} />}
      />
      <Formik
        initialValues={{ password: "", confirmPassword: "" }}
        onSubmit={(values) => {
          setPasswordAreMatched(values.password === values.confirmPassword);
          if (values.password === values.confirmPassword) {
            onStepForward();
          }
        }}
        validationSchema={ResetPasswordNewPasswordFormSchema}
        ref={animationParent}
      >
        {() => (
          <Form className={"flex flex-col gap-4"} ref={animationParent}>
            <PasswordInput
              name={"password"}
              title={"Password"}
              autoComplete={"new-password"}
              isNewPassword
            />
            <PasswordInput
              name={"confirmPassword"}
              title={"Confirm Password"}
              autoComplete={"current-password"}
            />
            {!passwordsAreMatched && (
              <ErrorView
                message={"Password and Confirm Password do not match "}
              />
            )}
            <button
              type="submit"
              className={
                "py-[10px] w-full px-10 text-white  font-medium  bg-accent hover:bg-tz-red-hover-dark rounded-lg text-sm transition-all duration-150 ease-in hover:bg-blue-800"
              }
            >
              Reset Password
            </button>
          </Form>
        )}
      </Formik>
    </div>
  );
};

ResetPasswordNewPasswordStep.propTypes = {
  onStepForward: PropTypes.func,
};

export default ResetPasswordNewPasswordStep;
