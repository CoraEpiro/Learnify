import { motion } from "framer-motion";
import ResetPasswordCard from "../../components/reset-password/reset-password-card/index.js";

const ForgotPasswordPage = () => {
  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={"w-full h-[90dvh]  flex justify-center items-center"}
    >
      <ResetPasswordCard
        title={"Forgot password?"}
        description={"No worries, we help you to reset password "}
        backUrlTitle={"Back to login"}
        backUrl={"/enter"}
      />
    </motion.div>
  );
};

export default ForgotPasswordPage;
