import { Outlet } from "react-router-dom";
import Header from "../header/index.js";
import Container from "../../container/index.js";
import LoginCard from "../../pages/enter-page/login-card/index.js";
import SideBar from "../../side-bar/index.js";

const Layout = () => {
  return (
    <div>
      <Header />
      <Container>
        <div className={"flex"}>
          <div className={"w-60 py-4 flex flex-col gap-4"}>
            <LoginCard />
            <SideBar />
          </div>
          <Outlet />
        </div>
      </Container>
    </div>
  );
};

export default Layout;
