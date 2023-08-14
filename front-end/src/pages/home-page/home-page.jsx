import { motion } from "framer-motion";
import LastQuestions from "../../components/pages/home-page/last-questions/index.js";
import LastAnswers from "../../components/pages/home-page/last-answers/index.js";
import LastArticles from "../../components/pages/home-page/last-articles/index.js";
import ArticleViewBy from "../../components/pages/home-page/article-view-by/index.js";

const HomePage = () => {
  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={"w-full flex justify-between  gap-4 py-4"}
    >
      <div className={"px-2"}>
        <ArticleViewBy />
      </div>
      <div className={"flex flex-col gap-5"}>
        <LastQuestions />
        <LastAnswers />
        <LastArticles />
      </div>
    </motion.div>
  );
};

export default HomePage;
