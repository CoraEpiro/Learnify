import PropTypes from "prop-types";
import { Form, Formik } from "formik";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import Checkbox from "../../../form/checkbox/index.js";
import { Link } from "react-router-dom";

const WelcomeCard = ({ name, onStepForward }) => {
  const [animationParent] = useAutoAnimate();

  document.title = "Build your Profile ! Learnify";

  return (
    <div className={"w-[550px] flex flex-col"} ref={animationParent}>
      {/*Header*/}
      <div
        className={
          "p-6 bg-[#090909] text-gray-50 rounded-t-lg flex flex-col gap-3"
        }
      >
        {/*Title*/}
        <p className={"font-bold  text-3xl flex flex-col gap-1"}>
          <span className={"text-4xl"}>{name}</span>
          <p>welcome to Learnify Community!</p>
        </p>
        <p className={"font-medium text-gray-300"}>
          A constructive and inclusive social network for software developers.
          With you every step of your journey.
        </p>
      </div>
      {/*Action Section*/}
      <div className={"p-6 bg-white text-white rounded-b-lg"}>
        <Formik
          initialValues={{ agreeCodeOfConduct: true, agreeTerms: true }}
          onSubmit={() => {
            onStepForward();
          }}
          ref={animationParent}
        >
          {({ values }) => (
            <Form
              className={"flex flex-col gap-4 text-black"}
              ref={animationParent}
            >
              <Checkbox
                name={"agreeCodeOfConduct"}
                className={"text-black"}
                renderTitle={
                  <p>
                    You agree to uphold our{" "}
                    <Link
                      to={"/code-of-conduct"}
                      target={"_blank"}
                      className={"text-accent underline-animation"}
                    >
                      Code of Conduct
                    </Link>
                    .
                  </p>
                }
              />
              <Checkbox
                name={"agreeTerms"}
                className={"text-black"}
                renderTitle={
                  <span>
                    You agree to our{" "}
                    <Link
                      to={"/terms"}
                      target={"_blank"}
                      className={"text-accent underline-animation"}
                    >
                      Terms and Conditions
                    </Link>
                    .
                  </span>
                }
              />
              <button
                disabled={!values.agreeTerms || !values.agreeCodeOfConduct}
                type="submit"
                className={
                  "py-[10px] w-fit self-center px-10 text-white disabled:bg-blue-950 disabled:cursor-not-allowed  font-medium  bg-accent  rounded-lg text-sm transition-all duration-150 ease-in hover:bg-blue-800"
                }
              >
                Continue
              </button>
            </Form>
          )}
        </Formik>
      </div>
    </div>
  );
};

WelcomeCard.propTypes = {
  name: PropTypes.string,
  onStepForward: PropTypes.func,
};

export default WelcomeCard;
