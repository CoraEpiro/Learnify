import { LuSearch } from "react-icons/lu";

const Search = () => {
  return (
    <div className={"w-[440px] h-9"}>
      <label
        htmlFor=""
        className={"relative  flex justify-center items-center  "}
      >
        <input
          className={
            "w-full h-9 bg-white placeholder-gray-900 text-sm border border-border-clr rounded-md py-2 pl-3   focus:outline-none hover:border-hover-border-clr focus:outline-accent focus:border-none transition-all duration-75"
          }
          type="text"
          name=""
          id=""
          placeholder={"Search..."}
        />
        <LuSearch
          size="38"
          className={
            "absolute top-[0px] right-[0px] flex items-center px-2 h-[36px] cursor-pointer hover:text-accent hover:bg-hover-blue-clr rounded-lg z-50 box-border"
          }
        />
      </label>
    </div>
  );
};

export default Search;
