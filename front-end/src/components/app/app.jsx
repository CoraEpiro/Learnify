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
import ContactPage from "../../pages/contact-page/index.js";
import CategoriesPage from "../../pages/categories-page/index.js";
import SideBarLayout from "../layout/side-bar-layout/index.js";
import Modal from "../../modals/index.jsx";
import { useModals } from "../../utils/modal.js";

const App = () => {
  return (
    <>
      <Router>
        <Routes>
          <Route path={"/"} element={<SideBarLayout />}>
            <Route path={"/"} element={<HomePage />} />
          </Route>
          <Route path={"/"} element={<Layout />}>
            <Route path={"/categories"} element={<CategoriesPage />} />
            <Route path={"/enter"} element={<EnterPage />} />
            <Route path={"/forgot-password"} element={<ForgotPasswordPage />} />
            <Route path={"/code-of-conduct"} element={<CodeOfConductPage />} />
            <Route path={"/contact"} element={<ContactPage />} />
            <Route path={"/privacy"} element={<PrivacyPage />} />
            <Route path={"/terms"} element={<TermsPage />} />
          </Route>
          <Route path={"/build-profile"} element={<BuildProfile />} />
          <Route path={"*"} element={<NotFoundPage />} />
        </Routes>
        {useModals().length > 0 && <Modal />}
      </Router>
    </>
  );
};

export default App;
