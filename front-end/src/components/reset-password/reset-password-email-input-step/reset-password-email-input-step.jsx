import ResetPasswordHeader from "../reset-password-header/index.js";
import { Form, Formik } from "formik";
import TextInput from "../../form/text-input/index.js";
import ResetPasswordBackUrl from "../reset-password-back-url/index.js";
import PropTypes from "prop-types";

const ResetPasswordEmailInputStep = ({
  title,
  description,
  backUrlTitle,
  backUrl,
  onStepForward,
}) => {
  return (
    <div className={"flex flex-col gap-4"}>
      <ResetPasswordHeader title={title} description={description} />
      <Formik
        initialValues={{ email: "" }}
        onSubmit={() => {
          onStepForward();
        }}
      >
        {() => (
          <Form className={"flex flex-col gap-4"}>
            <TextInput name={"email"} title={"Email"} autoComplete={"email"} />
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
      <ResetPasswordBackUrl backUrlTitle={backUrlTitle} backUrl={backUrl} />
    </div>
  );
};

ResetPasswordEmailInputStep.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  backUrlTitle: PropTypes.string,
  backUrl: PropTypes.string,
  onStepForward: PropTypes.func,
};

export default ResetPasswordEmailInputStep;
