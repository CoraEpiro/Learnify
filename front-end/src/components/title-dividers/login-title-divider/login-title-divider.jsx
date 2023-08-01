import TitleDivider from "../title-divider/index.js";

const LoginTitleDivider = () => {
  return (
    <TitleDivider
      title={
        <p className="text-sm text-center">
          Have a password? Continue with your email address
        </p>
      }
    />
  );
};

export default LoginTitleDivider;
