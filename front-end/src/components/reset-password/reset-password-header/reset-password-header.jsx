import PropTypes from "prop-types";
import { RiFingerprintFill } from "react-icons/ri";

const ResetPasswordHeader = ({ title, description }) => {
  return (
    <div className={"flex flex-col justify-center items-center gap-4 "}>
      {/*Icon*/}
      <RiFingerprintFill
        size={30}
        className={"border-[2px] border-border-clr rounded-lg box-content p-3"}
      />
      {/*Title*/}
      <p className={"text-3xl font-bold"}>{title}</p>
      {/*Description*/}
      <p className={"font-medium text-gray-600"}>{description}</p>
    </div>
  );
};

ResetPasswordHeader.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
};

export default ResetPasswordHeader;
