import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import classNames from "classnames";

const BaseLinkButton = ({ redirectUrl, title, renderTitle, startFlex }) => {
  return (
    <Link
      to={redirectUrl}
      className={classNames({
        "w-full h-9 bg-transparent flex items-center text-gray-700  rounded-lg py-2 px-4 hover:text-accent hover:bg-hover-blue-clr hover:underline transition-all duration-150 ": true,
        "justify-center": !startFlex,
        "justify-start": startFlex,
      })}
    >
      {title ? (
        <span className={"font-sans text-sm "}>Log in</span>
      ) : (
        renderTitle
      )}
    </Link>
  );
};

BaseLinkButton.propTypes = {
  redirectUrl: PropTypes.string,
  title: PropTypes.string,
  startFlex: PropTypes.bool,
  renderTitle: PropTypes.element,
};

export default BaseLinkButton;
