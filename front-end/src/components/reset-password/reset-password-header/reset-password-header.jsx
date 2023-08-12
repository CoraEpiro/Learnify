import PropTypes from "prop-types";

const ResetPasswordHeader = ({ title, description, icon }) => {
  return (
    <div className={"flex flex-col justify-center items-center gap-4 "}>
      {/*Icon*/}
      {icon}
      {/*Title*/}
      <p className={"text-3xl font-bold"}>{title}</p>
      {/*Description*/}
      <p className={"font-medium text-gray-600"}>{description}</p>
    </div>
  );
};

ResetPasswordHeader.propTypes = {
  title: PropTypes.string,
  description: PropTypes.any,
  icon: PropTypes.element,
};

export default ResetPasswordHeader;
