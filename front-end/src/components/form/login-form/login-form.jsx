import TextInput from "../text-input/index.js";
import Checkbox from "../checkbox/index.js";
import { Form, Formik } from "formik";
import PasswordInput from "../password-input/index.js";
import { Link } from "react-router-dom";

const LoginForm = () => {
  return (
    <Formik
      onSubmit={() => {}}
      initialValues={{ email: "", password: "", rememberMe: true }}
    >
      {() => (
        <Form className={"flex flex-col gap-4 "}>
          <TextInput title={"Email"} name={"email"} autoComplete={"email"} />
          <PasswordInput
            title={"Password"}
            name={"password"}
            autoComplete={"current-password"}
          />
          <Checkbox name={"rememberMe"} checked={true} title={"Remember me"} />
          <button
            type="submit"
            className={
              "py-[10px] w-full px-10 text-white  font-medium  bg-accent hover:bg-tz-red-hover-dark rounded-lg text-sm transition-all duration-150 ease-in hover:bg-blue-800"
            }
          >
            Continue
          </button>
          <Link
            to={"/forgot-password"}
            className={
              "w-fit text-sm underline-animation text-accent self-center"
            }
          >
            I forgot my password
          </Link>
        </Form>
      )}
    </Formik>
  );
};

export default LoginForm;
