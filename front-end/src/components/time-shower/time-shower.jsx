import PropTypes from "prop-types";

const TimeShower = ({ title, time }) => {
  return (
    <div
      className={
        "flex flex-col items-center bg-white  box-content px-3 py-1 rounded-lg"
      }
    >
      {/*Time*/}
      <span className={"font-semibold tex-bold text-3xl"}>
        {time < 10 ? `0${time}` : time}
      </span>
      {/*Title*/}
      <span className={"font-semibold text-sm text-medium"}>{title}</span>
    </div>
  );
};

TimeShower.propTypes = { title: PropTypes.string, time: PropTypes.number };

export default TimeShower;
