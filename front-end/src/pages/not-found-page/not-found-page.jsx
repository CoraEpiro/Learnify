import "./not-found-page.css";
import { Link } from "react-router-dom";
import { motion } from "framer-motion";

const NotFoundPage = () => {
  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={"w-[100dvw] h-[100dvh]"}
    >
      <div
        className={
          "w-[100%] h-[100%] flex items-center justify-center  flex-col"
        }
        style={{
          fontFamily: "'Gamja Flower', cursive",
        }}
      >
        <p className="not-found nt-p"> page not found </p>

        <div className="tipsiz">
          <div className="tipsiz-body">
            <div className="left-arm arm"></div>
            <div className="face">
              <div className="upper-face">
                <div className="element">4</div>
                <div className="element">0</div>
                <div className="element">4</div>
              </div>
              <div className="mouth"></div>
            </div>
            <div className="right-arm arm"></div>
          </div>
        </div>

        <p className={"nt-p"}>
          {" "}
          maybe you want to go{" "}
          <Link to="/" className={"nt-link"}>
            back?{" "}
          </Link>
        </p>
      </div>
    </motion.div>
  );
};

export default NotFoundPage;
