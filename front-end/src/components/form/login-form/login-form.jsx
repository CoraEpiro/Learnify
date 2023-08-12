import TextInput from "../text-input/index.js";
import Checkbox from "../checkbox/index.js";
import { Form, Formik } from "formik";
import PasswordInput from "../password-input/index.js";
import { Link } from "react-router-dom";
import { LoginSchema } from "../../../validation/Schemas/LoginSchema.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import PropTypes from "prop-types";

const LoginForm = ({ openLoginOtp }) => {
  const [animationParent] = useAutoAnimate();
  return (
    <Formik
      onSubmit={(values) => {
        openLoginOtp(values);
      }}
      initialValues={{ email: "", password: "", rememberMe: true }}
      validationSchema={LoginSchema}
      ref={animationParent}
    >
      {() => (
        <Form className={"flex flex-col gap-4 "} ref={animationParent}>
          <TextInput title={"Email"} name={"email"} autoComplete={"email"} />
          <PasswordInput
            title={"Password"}
            name={"password"}
            autoComplete={"current-password"}
          />

          <div className={"flex items-center justify-between"}>
            <Checkbox
              name={"rememberMe"}
              checked={true}
              title={"Remember me"}
            />
            <Link
              to={"/forgot-password"}
              className={
                "w-fit text-sm underline-animation text-accent self-center"
              }
            >
              I forgot my password
            </Link>
          </div>
          <button
            type="submit"
            className={
              "py-[10px] w-full px-10 text-white  font-medium  bg-accent hover:bg-tz-red-hover-dark rounded-lg text-sm transition-all duration-150 ease-in hover:bg-blue-800"
            }
          >
            Continue
          </button>
        </Form>
      )}
    </Formik>
  );
};

LoginForm.propTypes = {
  openLoginOtp: PropTypes.func,
};

export default LoginForm;
