import { motion } from "framer-motion";

const HomePage = () => {
  return (
    <motion.div initial={{ opacity: 0 }} animate={{ opacity: 1 }}></motion.div>
  );
};

export default HomePage;
