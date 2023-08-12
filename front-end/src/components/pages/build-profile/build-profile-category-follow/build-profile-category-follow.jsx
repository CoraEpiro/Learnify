import PropTypes from "prop-types";
import { AiFillCheckCircle } from "react-icons/ai";
import { BsCircle } from "react-icons/bs";
import classNames from "classnames";

const BuildProfileCategoryFollow = ({ tag, categoryFollowChange }) => {
  const { name, usedCount, isFollowed } = tag;
  return (
    <button
      onClick={() => {
        categoryFollowChange(name);
      }}
      className={classNames({
        "w-52 rounded-lg border-[2px] border-gray-500 p-3 flex items-center justify-between": true,
        "border-[#3B49DF] bg-build-selected-category-bg": isFollowed,
      })}
    >
      <div className={"flex items-start flex-col gap-1 text-sm"}>
        {/*Name*/}
        <p className={"font-bold"}>#{name}</p>
        {/*Used count*/}
        <p>{usedCount} time used</p>
      </div>
      <div
        className={classNames({ "text-xl": true, "text-accent": isFollowed })}
      >
        {isFollowed ? <AiFillCheckCircle /> : <BsCircle />}
      </div>
    </button>
  );
};

BuildProfileCategoryFollow.propTypes = {
  tag: PropTypes.object,
  categoryFollowChange: PropTypes.func,
};

export default BuildProfileCategoryFollow;
