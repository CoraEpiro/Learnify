import FilterOption from "../../../filter-option/index.js";

const ArticleViewBy = () => {
  return (
    <div className={"flex items-center gap-1"}>
      <FilterOption title={"Relevant"} isActive={true} />
      <FilterOption title={"Latest"} />
      <FilterOption title={"Top"} />
    </div>
  );
};

export default ArticleViewBy;
