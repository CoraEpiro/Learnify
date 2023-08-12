import SignupButton from "../signup-button/index.js";
import LoginButton from "../login-button/index.js";

const LoginCard = () => {
  return (
    <div className={"w-fit p-4 flex flex-col gap-3 bg-white rounded-lg"}>
      <p className={"text-xl font-bold"}>
        Learnify Community is a community of 1,110,244 amazing developers
      </p>
      <p className={"text-sm"}>
        We re a place where coders share, stay up-to-date and grow their
        careers.
      </p>
      <div className={"flex flex-col gap-1"}>
        <SignupButton />
        <LoginButton />
      </div>
    </div>
  );
};

export default LoginCard;
