import ResetPasswordHeader from "../reset-password-header/index.js";
import {Form, Formik} from "formik";
import TextInput from "../../form/text-input/index.js";

const ResetPasswordOtpStep = ({onStepForwad}) => {
  return (
      <div className={"flex flex-col gap-4"}>
        <ResetPasswordHeader title={"OTP"} description={"write otp code"} />
        <Formik
            initialValues={{ otp: "" }}
            onSubmit={() => {
              onStepForwad();
            }}
        >
          {() => (
              <Form className={"flex flex-col gap-4"}>
                <TextInput name={"otp"} title={"OTP"} autoComplete={"email"} />
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

export default ResetPasswordOtpStep;
