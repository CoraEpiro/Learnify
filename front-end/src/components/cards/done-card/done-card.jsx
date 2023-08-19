import CardHeader from "../card-header/index.js";
import { HiOutlineBadgeCheck } from "react-icons/hi";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

const DoneCard = ({ title, description, redirectUrl }) => {
  return (
    <div className={"flex flex-col gap-4"}>
      <CardHeader
        title={title}
        description={description}
        icon={<HiOutlineBadgeCheck size={30} className={"card-header-icon"} />}
      />
      <Link
        to={redirectUrl}
        className={
          "py-[10px] w-full px-10 text-white text-center font-medium  bg-accent hover:bg-tz-red-hover-dark rounded-lg text-sm transition-all duration-150 ease-in hover:bg-blue-800"
        }
      >
        Go to home
      </Link>
    </div>
  );
};

DoneCard.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  redirectUrl: PropTypes.string,
};

export default DoneCard;
