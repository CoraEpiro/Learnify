import PropTypes from "prop-types";

const Container = ({ children }) => {
  return (
    <div>
      <div className={"w-full h-full flex justify-center"}>
        <div className={"max-w-[1170px] h-full box-border px-4 w-full"}>
          {children}
        </div>
      </div>
    </div>
  );
};

Container.propTypes = {
  children: PropTypes.any,
};

export default Container;
