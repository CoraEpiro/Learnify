import { useState } from "react";
import BuildProfileCategoryFollow from "../build-profile-category-follow/index.js";
import { useAutoAnimate } from "@formkit/auto-animate/react";
import StepperStat from "../../../stepper-stat/index.js";
import classNames from "classnames";
import PropTypes from "prop-types";

const CategoryFollowStep = ({ onStepForward }) => {
  const [animationParent] = useAutoAnimate();

  const [categories, setCategories] = useState([
    { name: "vscode", usedCount: 5040, isFollowed: false },
    { name: "scala", usedCount: 610, isFollowed: false },
    { name: "sre", usedCount: 1057, isFollowed: false },
    { name: "aws", usedCount: 20703, isFollowed: false },
    { name: "elm", usedCount: 497, isFollowed: false },
    { name: "go", usedCount: 9403, isFollowed: false },
    { name: "devops", usedCount: 25977, isFollowed: false },
    { name: "JavaScript", usedCount: 200000, isFollowed: false },
    { name: "Python", usedCount: 180000, isFollowed: false },
    { name: "Java", usedCount: 160000, isFollowed: false },
    { name: "C#", usedCount: 140000, isFollowed: false },
    { name: "HTML/CSS", usedCount: 120000, isFollowed: false },
    { name: "React", usedCount: 100000, isFollowed: false },
    { name: "Angular", usedCount: 80000, isFollowed: false },
    { name: "Vue.js", usedCount: 60000, isFollowed: false },
    { name: "Node.js", usedCount: 40000, isFollowed: false },
    { name: "TypeScript", usedCount: 30000, isFollowed: false },
    { name: "PHP", usedCount: 50000, isFollowed: false },
    { name: "Swift", usedCount: 45000, isFollowed: false },
    { name: "Ruby", usedCount: 40000, isFollowed: false },
    { name: "C++", usedCount: 35000, isFollowed: false },
    { name: "Go", usedCount: 30000, isFollowed: false },
    { name: "Rust", usedCount: 25000, isFollowed: false },
    { name: "Perl", usedCount: 20000, isFollowed: false },
    { name: "Kotlin", usedCount: 18000, isFollowed: false },
  ]);

  const [followedCount, setFollowedCount] = useState(0);

  const handleCategoryFollowChange = (name) => {
    const updatedCategories = categories.map((category) =>
      category.name === name
        ? { ...category, isFollowed: !category.isFollowed }
        : category
    );

    setCategories(updatedCategories);

    const followedCategories = updatedCategories.filter(
      (category) => category.isFollowed
    );
    setFollowedCount(followedCategories.length);
  };

  return (
    <div className={"bg-white rounded-lg"} ref={animationParent}>
      <div
        className={
          "py-4 px-12 grid grid-cols-2 items-center justify-end  border-b-2 border-b-black"
        }
        ref={animationParent}
      >
        <div className={"w-full flex justify-end"}>
          <StepperStat totalStep={2} currentStep={1} />
        </div>

        <div className={"w-full flex justify-end"} ref={animationParent}>
          <button
            onClick={() => {
              onStepForward(
                categories.filter((category) => category.isFollowed)
              );
            }}
            className={classNames({
              "py-[10px] w-[170px] self-center px-10 text-black  font-medium   rounded-lg text-sm transition-all duration-500": true,
              "bg-accent hover:bg-blue-800 text-white": followedCount,
              "bg-[#d6d6d6] hover:bg-[#a3a3a3] ": !followedCount,
            })}
          >
            {!followedCount ? <p>Skip for now</p> : <p>Continue</p>}
          </button>
        </div>
      </div>
      <div className={"bg-black h-[1px] w-full"}></div>
      <div className={"py-4 px-12"} ref={animationParent}>
        {/*Stepper*/}
        {/*Header*/}
        <div></div>
        {/*Container*/}
        <div
          className={"flex flex-col gap-4 overflow-x-hidden overflow-scroll"}
          ref={animationParent}
        >
          {/*Header*/}
          <div>
            {/*Title*/}
            <div>
              <p className={"font-extrabold text-3xl"}>
                What are you interested in?
              </p>
              <p className={"font-medium text-xl"}>
                Follow tags to customize your feed
              </p>
            </div>
            {/*Stat*/}
            <div className={"flex items-center gap-1 text-gray-500 "}>
              <span>{followedCount}</span>
              <p>tags selected</p>
            </div>
          </div>
          <div
            className={" h-[410px]  grid grid-cols-3 gap-3 pr-2"}
            ref={animationParent}
          >
            {categories.map((tag) => (
              <BuildProfileCategoryFollow
                key={tag.name}
                tag={tag}
                categoryFollowChange={handleCategoryFollowChange}
              />
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

CategoryFollowStep.propTypes = {
  onStepForward: PropTypes.func,
};

export default CategoryFollowStep;
