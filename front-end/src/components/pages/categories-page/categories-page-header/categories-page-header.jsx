import Search from "../../../search/index.js";
import PrimaryButton from "../../../buttons/primary-button/index.js";

const CategoriesPageHeader = () => {
  return (
    <div className={"w-full flex items-center justify-between"}>
      {/*Title*/}
      <h1 className={"font-bold text-2xl"}>Categories</h1>
      {/*Action*/}
      <div className={"flex gap-1 "}>
        <PrimaryButton title={"Followed categories"} />
        <div className={"w-52"}>
          <Search placeHolder={"Search for category"} />
        </div>
      </div>
    </div>
  );
};

export default CategoriesPageHeader;
