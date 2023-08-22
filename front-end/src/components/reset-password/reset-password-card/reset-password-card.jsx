import PropTypes from "prop-types";
import { useState } from "react";
import ResetPasswordEmailInputStep from "../reset-password-email-input-step/index.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import ResetPasswordNewPasswordStep from "../reset-password-new-password-step/index.js";
import OtpVerificationCard from "../../cards/otp-verification-card/index.js";
import DoneCard from "../../cards/done-card/index.js";

const ResetPasswordCard = ({ title, description, backUrlTitle, backUrl }) => {
  const [animationParent] = useAutoAnimate();
  const [step, setStep] = useState(1);
  const [email, setEmail] = useState("");

  const handleOnStepForward = (email) => {
    if (email && email.length > 5) {
      setEmail(email);
    }
    setStep(step + 1);
  };

  const handleOnStepBack = () => {
    setStep(step - 1);
  };

  return (
    <div
      className={"bg-white rounded-lg flex flex-col gap-4 p-4 min-w-[400px]"}
      ref={animationParent}
    >
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
        <OtpVerificationCard
          onStepForward={handleOnStepForward}
          onStepBack={handleOnStepBack}
          email={email}
          onStepBackTitle={"Rewrite email"}
        />
      )}
      {step === 3 && (
        <ResetPasswordNewPasswordStep onStepForward={handleOnStepForward} />
      )}
      {step === 4 && (
        <DoneCard
          title={"All done!"}
          description={"Your password has been reset."}
          redirectUrl={"/"}
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
