import { Fragment } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Layout from "../layout/layout/index.js";
import NotFoundPage from "../../pages/not-found-page/index.js";
import HomePage from "../../pages/home-page/index.js";
import EnterPage from "../../pages/enter-page/index.js";
import ForgotPasswordPage from "../../pages/forgot-password-page/index.js";
import BuildProfile from "../../pages/build-profile/index.js";
import TermsPage from "../../pages/terms-page/index.js";
import PrivacyPage from "../../pages/privacy-page/index.js";
import CodeOfConductPage from "../../pages/code-of-conduct-page/index.js";
import BaseLayout from "../layout/base-layout/index.js";

const App = () => {
  return (
    <Router>
      <Fragment>
        <Routes>
          <Route path={"/"} element={<Layout />}>
            <Route path={"/"} element={<HomePage />} />
          </Route>
          <Route path={"/"} element={<BaseLayout />}>
            <Route path={"/enter"} element={<EnterPage />} />
            <Route path={"/forgot-password"} element={<ForgotPasswordPage />} />
            <Route path={"/terms"} element={<TermsPage />} />
            <Route path={"/privacy"} element={<PrivacyPage />} />
            <Route path={"/code-of-conduct"} element={<CodeOfConductPage />} />
          </Route>
          <Route path={"/build-profile"} element={<BuildProfile />} />
          <Route path={"*"} element={<NotFoundPage />} />
        </Routes>
      </Fragment>
    </Router>
  );
};

export default App;
