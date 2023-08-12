import Container from "../../container/index.js";
import Brand from "../../brand/index.js";
import Search from "../../search/index.js";
import LoginButton from "../../pages/enter-page/login-button/index.js";
import SignupButton from "../../pages/enter-page/signup-button/index.js";

const Header = () => {
  return (
    <div className={"w-full h-14 bg-white drop-shadow-sm"}>
      <Container>
        <div className={"w-full h-14 flex items-center "}>
          <div className={"w-fit flex items-center gap-4"}>
            <Brand />
            <Search />
          </div>
          <div className={"w-full  flex items-center justify-end gap-4"}>
            <div className={"w-20"}>
              <LoginButton />
            </div>
            <div className={"w-36"}>
              <SignupButton />
            </div>
          </div>
        </div>
      </Container>
    </div>
  );
};

export default Header;
