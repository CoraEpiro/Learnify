import PropTypes from "prop-types";
import { nanoid } from "nanoid";
import { BsCircleFill } from "react-icons/bs";
import classNames from "classnames";

const StepperStat = ({ totalStep, currentStep }) => {
  let html = [];
  for (let i = 0; i < totalStep; i++) {
    html.push({ isFinished: i < currentStep });
  }

  return (
    <div className={"flex gap-2"}>
      {html.map((step) => (
        <div
          key={nanoid()}
          className={classNames({
            "text-sm ": true,
            "text-gray-400": !step.isFinished,
            "text-accent": step.isFinished,
          })}
        >
          <BsCircleFill />
        </div>
      ))}
    </div>
  );
};

StepperStat.propTypes = {
  totalStep: PropTypes.number,
  currentStep: PropTypes.number,
};

export default StepperStat;
