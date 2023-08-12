import PropTypes from "prop-types";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import { motion } from "framer-motion";
import GithubEnter from "../github-enter/index.js";
import GoogleEnter from "../google-enter/index.js";
import LoginForm from "../../../form/login-form/index.js";
import SignupForm from "../../../form/signup-form/index.js";
import SignupTitleDivider from "../../../title-dividers/signup-title-divider/index.js";
import LoginTitleDivider from "../../../title-dividers/login-title-divider/index.js";

const EnterActionCard = ({ state, openSignupOtp, openLoginOtp }) => {
  const [animationParent] = useAutoAnimate();

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={"w-[640px]  bg-white rounded-lg flex flex-col gap-4  p-12"}
      ref={animationParent}
    >
      {/*Header*/}
      <div className={"font-sans flex flex-col items-center gap-2"}>
        <p className={"font-sans text-3xl font-bold"}>
          Welcome to Learnify Community
        </p>
        <p>Learnify Community is a community of 1,110,244 amazing developers</p>
      </div>
      {/*Provider Enter*/}
      <div className={"flex flex-col gap-4"} ref={animationParent}>
        <GithubEnter state={state} />
        <GoogleEnter state={state} />
      </div>
      {/*Info Divider*/}
      {state ? <SignupTitleDivider /> : <LoginTitleDivider />}
      {/*Form*/}
      {state ? (
        <SignupForm openSignupOtp={openSignupOtp} />
      ) : (
        <LoginForm openLoginOtp={openLoginOtp} />
      )}
    </motion.div>
  );
};

EnterActionCard.propTypes = {
  state: PropTypes.string,
  openSignupOtp: PropTypes.func,
  openLoginOtp: PropTypes.func,
};

export default EnterActionCard;
