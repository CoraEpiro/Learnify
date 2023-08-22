import { motion } from "framer-motion";
import CategoriesPageHeader from "../../components/pages/categories-page/categories-page-header/index.js";
import CategoriesContainer from "../../components/pages/categories-page/categories-container/index.js";

const CategoriesPage = () => {
  const categories = [
    {
      id: 1,
      title: "webdev",
      description: "Because the internet...",
      useCount: 124254,
      iconLink: "",
      accentColor: "#562765",
    },
    {
      id: 2,
      title: "javascript",
      description:
        "Once relegated to the browser as one of the 3 core technologies of the web, JavaScript can now be found almost anywhere you find code. JavaScript developers move fast and push software development forward; they can be as opinionated as the frameworks they use, so let's keep it clean here and make it a place to learn from each other!",
      useCount: 132800,
      iconLink:
        "https://res.cloudinary.com/practicaldev/image/fetch/s--QiqFhwmE--/c_limit,f_auto,fl_progressive,q_80,w_180/https://dev-to-uploads.s3.amazonaws.com/uploads/badge/badge_image/16/js-badge.png",
      accentColor: "#f7df1e",
    },
  ];
  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={"w-full flex flex-col  gap-4 py-4"}
    >
      <CategoriesPageHeader />
      <CategoriesContainer categoriesData={categories} />
    </motion.div>
  );
};

export default CategoriesPage;
