import PropTypes from "prop-types";
import { AiOutlineCheck, AiOutlineClose } from "react-icons/ai";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import { useEffect, useState } from "react";

const PasswordCondition = ({ value, pattern, title }) => {
  const [animationParent] = useAutoAnimate();

  const checkIsValid = new RegExp(pattern).test(value);

  const [isValid, setIsValid] = useState(checkIsValid);

  useEffect(() => {
    setIsValid(checkIsValid);
  }, [value]);

  return (
    <div className={"flex items-center gap-2"} ref={animationParent}>
      {isValid ? (
        <AiOutlineCheck fill={"green"} />
      ) : (
        <AiOutlineClose fill={"red"} />
      )}
      <p>{title}</p>
    </div>
  );
};

PasswordCondition.propTypes = {
  value: PropTypes.string,
  title: PropTypes.string,
  pattern: PropTypes.string,
};

export default PasswordCondition;
