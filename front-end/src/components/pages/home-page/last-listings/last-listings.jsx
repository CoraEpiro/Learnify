import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import { nanoid } from "nanoid";

const LastListings = ({ title, data, seeAllUrl }) => {
  return (
    <div
      className={
        "w-72 pb-2 border border-border-clr  flex flex-col gap-1 bg-white rounded-lg"
      }
    >
      {/*Header*/}
      <div className={"flex items-center justify-between p-3"}>
        {/*Title*/}
        <span className={"text-lg font-bold"}>{title}</span>
        {/*See all*/}
        <Link
          to={seeAllUrl}
          className={"text-sm text-accent underline-animation"}
        >
          See all
        </Link>
      </div>
      <div className={"flex flex-col"}>
        {data.map((item) => (
          <Link
            to={item.url}
            key={nanoid()}
            className={
              "group p-4 cursor-pointer border-t border-border-clr text-sm text-gray-700 flex flex-col gap-1"
            }
          >
            <p className={"group-hover:text-accent"}>{item.title}</p>
            <span className={"text-xs whitespace-pre"}>{item.description}</span>
          </Link>
        ))}
      </div>
    </div>
  );
};

LastListings.propTypes = {
  title: PropTypes.string,
  data: PropTypes.array,
  seeAllUrl: PropTypes.string,
};

export default LastListings;
