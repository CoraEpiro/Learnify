import PropTypes from "prop-types";
import { AiOutlineArrowLeft } from "react-icons/ai";
import { Link } from "react-router-dom";
const ResetPasswordBackUrl = ({ backUrlTitle, backUrl }) => {
  return (
    <Link
      to={backUrl}
      className={
        "flex items-center self-center gap-4 hover:bg-hover-blue-clr p-2 rounded-lg cursor-pointer smooth-animation"
      }
    >
      {/*Icon*/}
      <AiOutlineArrowLeft />
      {/*Link*/}

      <p>{backUrlTitle}</p>
    </Link>
  );
};

ResetPasswordBackUrl.propTypes = {
  backUrlTitle: PropTypes.string,
  backUrl: PropTypes.string,
};

export default ResetPasswordBackUrl;
