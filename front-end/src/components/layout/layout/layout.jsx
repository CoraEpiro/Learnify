import { Outlet } from "react-router-dom";
import Header from "../header/index.js";
import Container from "../../container/index.js";

const Layout = () => {
  return (
    <div>
      <Header />
      <Container>
        <Outlet />
      </Container>
    </div>
  );
};

export default Layout;
