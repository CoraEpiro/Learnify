import PropTypes from "prop-types";
import { useState } from "react";
import ResetPasswordEmailInputStep from "../reset-password-email-input-step/index.js";
import ResetPasswordOtpStep from "../reset-password-otp-step/index.js";

const ResetPasswordCard = ({ title, description, backUrlTitle, backUrl }) => {
  const [step, setStep] = useState(1);

  const handleOnStepForward = () => {
    setStep(step + 1);
  };

  const handleOnStepBack = () => {
    setStep(step - 1);
  };

  return (
    <div className={"bg-white rounded-lg flex flex-col gap-4 p-4"}>
      {step === 1 && (
        <ResetPasswordEmailInputStep
          title={title}
          description={description}
          backUrlTitle={backUrlTitle}
          backUrl={backUrl}
          onStepForward={handleOnStepForward}
        />
      )}
      {step === 2 && (
        <ResetPasswordOtpStep
          onStepBack={handleOnStepBack}
          email={"kenanysbv@gmail.com"}
        />
      )}
    </div>
  );
};

ResetPasswordCard.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  backUrlTitle: PropTypes.string,
  backUrl: PropTypes.string,
};

export default ResetPasswordCard;
