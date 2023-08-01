import { Link } from "react-router-dom";

const LoginButton = () => {
  return (
    <Link
      to={"/enter"}
      className={
        "w-full h-10 bg-transparent flex items-center justify-center rounded-lg py-2 px-4 hover:bg-hover-blue-clr hover:underline transition-all duration-150 "
      }
    >
      <span className={"font-sans text-sm text-gray-700"}>Log in</span>
    </Link>
  );
};

export default LoginButton;
