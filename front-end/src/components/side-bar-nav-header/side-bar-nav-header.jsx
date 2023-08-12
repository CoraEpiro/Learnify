import PropTypes from "prop-types";

const SideBarNavHeader = ({ title }) => {
  return (
    <div className={"flex items-center  "}>
      <div className={"w-fit p-1 rounded-lg flex items-center gap-2   "}>
        {/*<img*/}
        {/*  src={`../../public/${iconName}.png`}*/}
        {/*  alt={title}*/}
        {/*  className={"h-[20px]"}*/}
        {/*/>*/}
        <span className={"font-sans font-bold text-gray-600"}>{title}</span>
      </div>
    </div>
  );
};

SideBarNavHeader.propTypes = {
  title: PropTypes.string,
};

export default SideBarNavHeader;
