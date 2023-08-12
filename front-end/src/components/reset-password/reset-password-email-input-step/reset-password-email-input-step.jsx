import ResetPasswordHeader from "../reset-password-header/index.js";
import { Form, Formik } from "formik";
import TextInput from "../../form/text-input/index.js";
import ResetPasswordBackUrl from "../reset-password-back-url/index.js";
import PropTypes from "prop-types";
import { RiFingerprintFill } from "react-icons/ri";
import { ResetPasswordEmailFormSchema } from "../../../validation/Schemas/ResetPasswordEmailFormSchema.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";

const ResetPasswordEmailInputStep = ({
  title,
  description,
  backUrlTitle,
  backUrl,
  onStepForward,
}) => {
  const [animationParent] = useAutoAnimate();
  return (
    <div className={"flex flex-col gap-4"} ref={animationParent}>
      <ResetPasswordHeader
        title={title}
        description={description}
        icon={
          <RiFingerprintFill
            size={30}
            className={"reset-password-header-icon"}
          />
        }
      />
      <Formik
        initialValues={{ email: "" }}
        onSubmit={(values) => {
          onStepForward(values.email);
        }}
        validationSchema={ResetPasswordEmailFormSchema}
        ref={animationParent}
      >
        {() => (
          <Form className={"flex flex-col gap-4"} ref={animationParent}>
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
