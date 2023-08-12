import { useAutoAnimate } from "@formkit/auto-animate/react";
import { useEffect, useState } from "react";
import { useTimer } from "react-timer-hook";
import ResetPasswordHeader from "../reset-password/reset-password-header/index.js";
import { LuMailOpen } from "react-icons/lu";
import TimeShower from "../time-shower/index.js";
import OtpInput from "react-otp-input";
import ErrorView from "../error-view/index.js";
import PropTypes from "prop-types";
import "./otp-verification-card.css";
import AccordionCollapse from "../accordion/index.js";
import { SiMicrosoftoutlook } from "react-icons/si";
import { BiLogoGmail } from "react-icons/bi";
import { AiOutlineArrowLeft } from "react-icons/ai";

const OtpVerificationCard = ({
  onStepForward,
  onStepBack,
  email,
  onStepBackTitle,
}) => {
  const [animationParent] = useAutoAnimate();

  const [otp, setOtp] = useState("");
  const [otpIsWrong, setOtpIsWrong] = useState(false);

  const time = new Date();
  time.setSeconds(time.getSeconds() + 120);

  const { seconds, minutes, restart } = useTimer({
    expiryTimestamp: time,
    onExpire: () => console.warn("onExpire called"),
  });

  const checkOtp = () => {
    return otp === "1234";
  };

  const resetOtp = () => {
    setOtpIsWrong(false);
    setOtp("");
    const time = new Date();
    time.setSeconds(time.getSeconds() + 120);
    restart(time);
  };

  useEffect(() => {
    if (otp.length === 4) {
      if (checkOtp()) {
        setOtpIsWrong(false);
        onStepForward();
      } else {
        setOtpIsWrong(true);
      }
    }
  }, [otp]);

  return (
    <div
      className="bg-white rounded-lg flex flex-col gap-4 p-4 min-w-[400px]"
      ref={animationParent}
    >
      <div className={"flex flex-col gap-4"} ref={animationParent}>
        <ResetPasswordHeader
          title={"Password Reset"}
          description={
            <p className={"text-gray-900"}>
              We sent a code to <span className={"font-bold"}>{email}</span>{" "}
            </p>
          }
          icon={
            <LuMailOpen size={30} className={"reset-password-header-icon"} />
          }
        />
        <div className={"flex items-center text-center gap-4 justify-center"}>
          <TimeShower title={"Minutes"} time={minutes} />

          <span className={"h-[35px] p-0 m-0 text-center text-2xl"}>:</span>

          <TimeShower title={"Seconds"} time={seconds} />
        </div>

        <OtpInput
          value={otp}
          onChange={setOtp}
          numInputs={4}
          renderSeparator={<span>-</span>}
          containerStyle={"flex gap-4 justify-center items-center"}
          renderInput={(props) => <input name={"otp"} {...props} />}
          inputStyle={
            "text-[2rem]  w-12 h-12 px-2 py-1 box-content border-[1px] border-border-clr  rounded-lg"
          }
          inputType={"number"}
        />

        {otpIsWrong && (
          <div className={"w-fit self-center"}>
            <ErrorView message={"Wrong OTP"} />
          </div>
        )}

        <button className={"flex gap-2 text-sm self-center"} onClick={resetOtp}>
          <p> Didn&#39;t receive the email?</p>
          <button>
            <span className={"text-accent font-medium underline-animation"}>
              Click to resend
            </span>
          </button>
        </button>
        <button
          onClick={() => {
            onStepBack();
          }}
          className={
            "flex items-center self-center gap-4 hover:bg-hover-blue-clr p-2 rounded-lg cursor-pointer smooth-animation"
          }
        >
          {/*Icon*/}
          <AiOutlineArrowLeft />
          {/*Link*/}

          <p>{onStepBackTitle}</p>
        </button>
        <AccordionCollapse title={"Quick view OTP"}>
          <div className={"flex flex-col gap-1"}>
            <a
              href={"https://outlook.com"}
              target="_blank"
              rel="noreferrer"
              className={`w-full min-h-6 p-3 pl-3 pr-5 rounded-lg flex justify-center items-center gap-2 text-white font-medium transition-all duration-150 bg-accent hover:bg-blue-900 `}
            >
              <SiMicrosoftoutlook size={24} />
              Open Outlook Web
            </a>
            <a
              href={"https://mail.google.com/"}
              target="_blank"
              rel="noreferrer"
              className={`w-full min-h-6 p-3 pl-3 pr-5 rounded-lg flex justify-center items-center gap-2 text-white font-medium transition-all duration-150 bg-red-700 hover:bg-red-900 `}
            >
              <BiLogoGmail size={24} />
              Open Gmail Web
            </a>
          </div>
        </AccordionCollapse>
      </div>
    </div>
  );
};

OtpVerificationCard.propTypes = {
  onStepForward: PropTypes.func,
  onStepBack: PropTypes.func,
  email: PropTypes.string,
  onStepBackTitle: PropTypes.string,
};

export default OtpVerificationCard;
