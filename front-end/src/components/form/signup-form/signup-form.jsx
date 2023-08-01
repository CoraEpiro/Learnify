import { Form, Formik } from "formik";
import TextInput from "../text-input/index.js";
import PasswordInput from "../password-input/index.js";
import Checkbox from "../checkbox/index.js";
import { Link } from "react-router-dom";

const SignupForm = () => {
  return (
    <Formik
      onSubmit={() => {}}
      initialValues={{
        email: "",
        password: "",
        confirmPassword: "",
        rememberMe: true,
      }}
    >
      {() => (
        <Form className={"flex flex-col gap-4 "}>
          <TextInput title={"Email"} name={"email"} autoComplete={"email"} />
          <PasswordInput
            title={"Password"}
            name={"password"}
            autoComplete={"new-password"}
          />
          <PasswordInput
            title={"Confirm Password"}
            name={"confirmPassword"}
            autoComplete={"current-password"}
          />
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

export default SignupForm;
