import PropTypes from "prop-types";
import PrimaryAccentButton from "../../../primary-accent-button/index.js";
import LimitedText from "../../../limited-text/index.js";
import CategoryTitle from "../category-title/index.js";

const Category = ({ category }) => {
  //   id: 2,
  //   title: "webdev",
  //   description: "",
  //   useCount: 123,
  //   iconLink: "",
  //   accentColor: "",

  function divideNumber(number) {
    const str = number.toString();
    const parts = [];

    for (let i = str.length - 1; i >= 0; i -= 3) {
      const part = str.substring(Math.max(0, i - 2), i + 1);
      parts.unshift(part);
    }

    return parts.join(",");
  }

  return (
    <div
      className={
        "w-[310px] h-44 bg-white rounded-lg border border-border-clr px-5 py-4 flex flex-col justify-between"
      }
    >
      <div className={"flex flex-col gap-1"}>
        {/*Header*/}
        <div className={"flex items-center justify-between gap-1 "}>
          {/*Title*/}
          <h1>
            <CategoryTitle
              title={category.title}
              color={category.accentColor}
            />
          </h1>
          {/*Used Count*/}
          <p className={"text-dark-text text-xs"}>
            <span>{divideNumber(category.useCount)}</span> time used
          </p>
        </div>
        {/*Description*/}
        <p className={"text-second-text text-sm"}>
          <LimitedText text={category.description} limit={110} />
        </p>
        {/*Footer*/}
      </div>
      <div>
        {/*Follow button*/}
        <PrimaryAccentButton title={"Follow"} />
        {/*Icon*/}
      </div>
    </div>
  );
};

Category.propTypes = {
  category: PropTypes.object,
};

export default Category;
