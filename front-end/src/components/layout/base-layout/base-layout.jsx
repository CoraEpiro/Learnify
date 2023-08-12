import Header from "../header/index.js";
import Container from "../../container/index.js";
import { Outlet } from "react-router-dom";

const BaseLayout = () => {
  return (
    <div>
      <Header />
      <Container>
        <Outlet />
      </Container>
    </div>
  );
};

export default BaseLayout;
