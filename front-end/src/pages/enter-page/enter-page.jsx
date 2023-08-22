import { motion } from "framer-motion";
import { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import EnterActionCard from "../../components/pages/enter-page/enter-action-card/index.js";
import OtpVerificationCard from "../../components/cards/otp-verification-card/index.js";

const EnterPage = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const initialState = queryParams.get("state");
  const [state, setState] = useState(initialState);
  const [values, setValues] = useState("");
  const [otpOptions, setOtpOptions] = useState({});
  const [otpEnabled, setOtpEnabled] = useState(false);
  const navigate = useNavigate();

  const handleOpenSignupOtp = (signUpValues) => {
    // email: "",password: "",confirmPassword: "",rememberMe: true,
    const { email } = signUpValues;
    setOtpOptions({
      email: email,
      backTitle: "Back to Sign Up",
      backUrl: "/enter?state=new-user",
      forwardUrl: `/build-profile?email=${email}`,
    });
    setValues(values);
    setOtpEnabled(true);
  };
  const handleOpenLoginOtp = (loginValues) => {
    // email: "", password: "", rememberMe: true
    const { email } = loginValues;
    setOtpOptions({
      email: email,
      backTitle: "Back to Login",
      backUrl: "/enter",
      forwardUrl: `/build-profile?email=${email}`,
    });
    setValues(values);
    setOtpEnabled(true);
  };

  const handleOtpOnStepForward = () => {
    navigate(otpOptions.forwardUrl);
    setOtpEnabled(false);
  };
  const handleOtpOnStepBack = () => {
    navigate(otpOptions.backUrl);
    setOtpEnabled(false);
  };

  useEffect(() => {
    const queryParams = new URLSearchParams(location.search);
    const newState = queryParams.get("state");
    setState(newState);
  }, [location.search]);

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={"flex justify-center p-4"}
    >
      {otpEnabled ? (
        <OtpVerificationCard
          email={otpOptions.email}
          onStepBackTitle={otpOptions.backTitle}
          onStepForward={handleOtpOnStepForward}
          onStepBack={handleOtpOnStepBack}
        />
      ) : (
        <EnterActionCard
          state={state}
          openLoginOtp={handleOpenLoginOtp}
          openSignupOtp={handleOpenSignupOtp}
        />
      )}
    </motion.div>
  );
};

export default EnterPage;
