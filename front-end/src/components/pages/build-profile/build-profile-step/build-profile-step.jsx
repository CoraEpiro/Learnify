import StepperStat from "../../../stepper-stat/index.js";
import classNames from "classnames";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import BuildProfileProfilePhoto from "../build-profile-profile-photo/index.js";
import PropTypes from "prop-types";
import { Form, Formik } from "formik";
import TextInput from "../../../form/text-input/index.js";
import TextAreaInput from "../../../form/text-area-input/index.js";
import ErrorView from "../../../error-view/index.js";
import { useEffect, useState } from "react";

const BuildProfileStep = ({ user, onStepForward }) => {
  const [animationParent] = useAutoAnimate();

  const [userNameIsAvailable, setUserNameIsAvailable] = useState(false);
  const [userName, setUserName] = useState("");

  const checkUserName = () => {
    if (userName === "kanan") {
      setUserNameIsAvailable(false);
    } else {
      setUserNameIsAvailable(true);
    }
  };

  useEffect(() => {
    setTimeout(() => {
      checkUserName();
    }, 1000);
  }, [userName]);

  return (
    <div className={"bg-white rounded-lg"} ref={animationParent}>
      <div
        className={
          "py-4 px-12 grid grid-cols-2 items-center justify-end  border-b-2 border-b-black"
        }
        ref={animationParent}
      >
        <div className={"w-full flex justify-end"}>
          <StepperStat totalStep={2} currentStep={2} />
        </div>

        <div className={"w-full flex justify-end"} ref={animationParent}>
          <button
            onClick={() => {
              onStepForward();
            }}
            className={classNames({
              "py-[10px] w-[170px] self-center px-10 text-black  font-medium   rounded-lg text-sm transition-all duration-500": true,
              "bg-accent hover:bg-blue-800 text-white": true,
              "bg-[#d6d6d6] hover:bg-[#a3a3a3] ": false,
            })}
          >
            <p>Build Profile</p>
          </button>
        </div>
      </div>
      <div className={"bg-black h-[1px] w-full"}></div>
      <div className={"w-[780px] py-4 px-12"} ref={animationParent}>
        {/*Container*/}
        <div
          className={"flex flex-col gap-10 overflow-x-hidden overflow-scroll"}
          ref={animationParent}
        >
          {/*Header*/}
          <div>
            {/*Title*/}
            <div className={"flex flex-col gap-1"}>
              <p className={"font-extrabold text-3xl"}>Build your profile</p>
              <p className={"font-medium text-xl"}>
                Tell us a little bit about yourself — this is how others will
                see you on Learnify Community. You&lsquo;ll always be able to
                edit this later in your Settings.
              </p>
            </div>
          </div>
          <div className={" w-full h-[410px] pr-2 py-2"} ref={animationParent}>
            <Formik
              initialValues={{
                userName: "",
                bio: "",
                websiteUrl: "",
                work: "",
                education: "",
              }}
              onSubmit={() => {}}
            >
              {({ values }) => {
                setUserName(values.userName);
                return (
                  <Form className={"flex flex-col gap-5 p-1"}>
                    <BuildProfileProfilePhoto userName={user.name} />
                    {!userNameIsAvailable && (
                      <ErrorView message={"This Username is not available"} />
                    )}

                    <TextInput
                      name={"userName"}
                      title={"Username"}
                      placeholder={"Enter your username"}
                      autoComplete={"username"}
                    />

                    <TextAreaInput
                      name={"bio"}
                      title={"Bio"}
                      maxLength={200}
                      placeholder={"Tell us a little about yourself"}
                    />

                    <TextInput
                      name={"websiteUrl"}
                      title={"Website Url"}
                      placeholder={"Enter your website url"}
                      autoComplete={"url"}
                    />

                    <div className={"flex flex-col gap-3"}>
                      {/*Header*/}
                      <p className={"font-bold text-2xl"}>Work</p>
                      <TextInput
                        name={"work"}
                        title={"Work"}
                        placeholder={
                          "What do you do? Example: CEO at Google Inc."
                        }
                        autoComplete={"organization-title"}
                      />
                      <TextInput
                        name={"education"}
                        title={"Education"}
                        placeholder={
                          "Where did you go to school? Example: Student at Step It Academy"
                        }
                      />
                    </div>
                  </Form>
                );
              }}
            </Formik>
          </div>
        </div>
      </div>
    </div>
  );
};

BuildProfileStep.propTypes = {
  user: PropTypes.object,
  onStepForward: PropTypes.func,
};

export default BuildProfileStep;
