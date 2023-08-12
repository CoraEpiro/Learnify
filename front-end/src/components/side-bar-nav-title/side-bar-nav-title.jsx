import PropTypes from "prop-types";

const SideBarNavTitle = ({ title, iconName }) => {
  return (
    <div className={"flex items-center gap-2 "}>
      <img
        src={`../../public/${iconName}.png`}
        alt={title}
        className={"h-[20px]"}
      />
      <span className={"font-sans text-lg "}>{title}</span>
    </div>
  );
};

SideBarNavTitle.propTypes = {
  title: PropTypes.string,
  iconName: PropTypes.string,
};

export default SideBarNavTitle;
