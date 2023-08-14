import { motion } from "framer-motion";

const ContactPage = () => {
  document.title = "Code of Conduct for Learnify";

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={
        "mt-3 px-16 py-8 mx-28 bg-white rounded-lg flex flex-col gap-4"
      }
    >
      <h1 className="primary-header">Contacts</h1>
      <p className="text">Learnify Community would love to hear from you!</p>
      <p className={"text"}>
        Email:{" "}
        <a href="mailto:yo@dev.to" className="underline-animation text-accent">
          yo@dev.to
        </a>{" "}
        😁
      </p>
    </motion.div>
  );
};

export default ContactPage;
