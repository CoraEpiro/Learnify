import { Outlet } from "react-router-dom";
import Header from "../header/index.js";
import Container from "../../container/index.js";
import "./layout.css";

const Layout = () => {
  document.title = "Learnify";

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
