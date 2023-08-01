import { Link } from "react-router-dom";
import TitleDivider from "../title-divider/index.js";

const SignupTitleDivider = () => {
  return (
    <TitleDivider
      title={
        <p className="text-sm text-center">
          Already have an account?{" "}
          <Link
            to={"/enter"}
            className={"text-sm text-accent underline-animation"}
          >
            Log in.
          </Link>
        </p>
      }
    />
  );
};

export default SignupTitleDivider;
