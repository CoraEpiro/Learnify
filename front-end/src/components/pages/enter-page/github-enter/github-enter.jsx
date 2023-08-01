import PropTypes from "prop-types";
import { AiFillGithub } from "react-icons/ai";

const GithubEnter = ({ state }) => {
  const providerTitlePrefix = state ? "Sign Up" : "Continue";

  return (
    <button
      className={`w-full min-h-6 p-3 pl-3 pr-5 rounded-lg flex justify-center items-center gap-2 text-white font-medium transition-all duration-150 bg-github-bg hover:bg-github-hover-bg `}
    >
      <AiFillGithub size={24} />
      {`${providerTitlePrefix} with GitHub`}
    </button>
  );
};

GithubEnter.propTypes = {
  state: PropTypes.object,
};

export default GithubEnter;
