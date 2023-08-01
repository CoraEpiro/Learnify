import LoginCard from "../../components/pages/enter-page/login-card/index.js";
import { motion } from "framer-motion";

const HomePage = () => {
  return (
    <motion.div initial={{ opacity: 0 }} animate={{ opacity: 1 }}>
      <div className={"w-60 py-4"}>
        <LoginCard />
      </div>
    </motion.div>
  );
};

export default HomePage;
