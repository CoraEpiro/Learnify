import PropTypes from "prop-types";
import Category from "../category/index.js";

const CategoriesContainer = ({ categoriesData }) => {
  return (
    <div className={"flex gap-4"}>
      {categoriesData.map((category) => (
        <Category key={category.id} category={category} />
      ))}
    </div>
  );
};

CategoriesContainer.propTypes = {
  categoriesData: PropTypes.array,
};

export default CategoriesContainer;
