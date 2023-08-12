import { motion } from "framer-motion";
import "./build-profile.css";
import { useState } from "react";
import WelcomeCard from "../../components/pages/build-profile/welcome-card/index.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import CategoryFollowStep from "../../components/pages/build-profile/category-follow-step/index.js";
import BuildProfileStep from "../../components/pages/build-profile/build-profile-step/index.js";
import DoneCard from "../../components/done-card/index.js";

const BuildProfile = () => {
  const [step, setStep] = useState(1);
  const [animationParent] = useAutoAnimate();

  const queryParams = new URLSearchParams(location.search);

  const email = queryParams.get("email");

  const user = {
    name: "Kanan Yusubov",
    email: email,
  };

  const handleOnStepForward = () => {
    setStep(step + 1);
  };

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={
        "w-[100dvw] h-[100dvh] build-profile-bg flex items-center justify-center "
      }
      ref={animationParent}
    >
      {step === 1 && (
        <WelcomeCard onStepForward={handleOnStepForward} name={user.name} />
      )}

      {step === 2 && <CategoryFollowStep onStepForward={handleOnStepForward} />}

      {step === 3 && (
        <BuildProfileStep user={user} onStepForward={handleOnStepForward} />
      )}

      {step === 4 && (
        <div className={"bg-white rounded-lg p-4 min-w-[400px]"}>
          <DoneCard
            title={"All done!"}
            description={"Your profile is built!"}
            redirectUrl={"/"}
          />
        </div>
      )}
    </motion.div>
  );
};

export default BuildProfile;
