import { Link } from "react-router-dom";

const SignupButton = () => {
  return (
    <Link
      to={"/enter?state=new-user"}
      className={
        "w-full h-10 flex justify-center items-center text-sm text-accent font-medium border-[1px] border-accent rounded-lg hover:text-white hover:underline hover:bg-accent transition-all duration-150"
      }
    >
      Create Account
    </Link>
  );
};

export default SignupButton;
