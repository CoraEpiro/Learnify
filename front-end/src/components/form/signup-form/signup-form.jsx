import { Form, Formik } from "formik";
import TextInput from "../text-input/index.js";
import PasswordInput from "../password-input/index.js";
import Checkbox from "../checkbox/index.js";
import { SignUpSchema } from "../../../validation/Schemas/SignUpSchema.js";
import { useState } from "react";
import ErrorView from "../../error-view/index.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import PropTypes from "prop-types";

const SignupForm = ({ openSignupOtp }) => {
  const [animationParent] = useAutoAnimate();

  const [passwordsAreMatched, setPasswordAreMatched] = useState(true);

  return (
    <Formik
      onSubmit={(values) => {
        setPasswordAreMatched(values.password === values.confirmPassword);
        if (values.password === values.confirmPassword) {
          openSignupOtp(values);
        }
      }}
      initialValues={{
        name: "",
        email: "",
        password: "",
        confirmPassword: "",
        rememberMe: true,
      }}
      validationSchema={SignUpSchema}
      ref={animationParent}
    >
      {() => (
        <Form className={"flex flex-col gap-4 "} ref={animationParent}>
          <TextInput title={"Name"} name={"name"} autoComplete={"name"} />
          <TextInput title={"Email"} name={"email"} autoComplete={"email"} />
          <PasswordInput
            title={"Password"}
            name={"password"}
            autoComplete={"new-password"}
            isNewPassword
          />
          <PasswordInput
            title={"Confirm Password"}
            name={"confirmPassword"}
            autoComplete={"current-password"}
          />
          {!passwordsAreMatched && (
            <ErrorView
              message={"Password and Confirm Password do not match "}
            />
          )}
          <Checkbox name={"rememberMe"} checked={true} title={"Remember me"} />
          <button
            type="submit"
            className={
              "py-[10px] w-full px-10 text-white  font-medium  bg-accent hover:bg-tz-red-hover-dark rounded-lg text-sm transition-all duration-150 ease-in hover:bg-blue-800"
            }
          >
            Sign Up
          </button>
        </Form>
      )}
    </Formik>
  );
};

SignupForm.propTypes = {
  openSignupOtp: PropTypes.bool,
};

export default SignupForm;
