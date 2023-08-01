import { Fragment } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Layout from "../layout/layout/index.js";
import NotFoundPage from "../../pages/not-found-page/index.js";
import HomePage from "../../pages/home-page/index.js";
import EnterPage from "../../pages/enter-page/index.js";
import ForgotPasswordPage from "../../pages/forgot-password-page/index.js";

const App = () => {
  return (
    <Router>
      <Fragment>
        <Routes>
          <Route path={"/"} element={<Layout />}>
            <Route path={"/"} element={<HomePage />} />
            <Route path={"/enter"} element={<EnterPage />} />
            <Route path={"/forgot-password"} element={<ForgotPasswordPage />} />
          </Route>
          <Route path={"*"} element={<NotFoundPage />} />
        </Routes>
      </Fragment>
    </Router>
  );
};

export default App;
