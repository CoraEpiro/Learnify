import { motion } from "framer-motion";
import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import EnterActionCard from "../../components/pages/enter-page/enter-action-card/index.js";

const EnterPage = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const initialState = queryParams.get("state");
  const [state, setState] = useState(initialState);

  useEffect(() => {
    const queryParams = new URLSearchParams(location.search);
    const newState = queryParams.get("state");
    setState(newState);
  }, [location.search]);

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={"flex justify-center p-4"}
    >
      <EnterActionCard state={state} />
    </motion.div>
  );
};

export default EnterPage;
