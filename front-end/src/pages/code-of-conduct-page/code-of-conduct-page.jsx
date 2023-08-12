import { motion } from "framer-motion";
import "./code-of-conduct-page.css";

const CodeOfConductPage = () => {
  document.title = "Code of Conduct for Learnify";

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={
        "mt-3 px-16 py-8 mx-28 bg-white rounded-lg flex flex-col gap-4"
      }
    >
      <h1 className="primary-header">Learnify Code of Conduct</h1>

      <h3 className="header">Purpose</h3>
      <p className="text">
        Learnify is a collaborative learning platform where individuals come
        together to share knowledge, ideas, and support each other in their
        learning journeys. We believe in fostering a welcoming and inclusive
        environment that encourages respectful and constructive interactions.
        This Code of Conduct outlines our expectations for all members of the
        Learnify community to ensure a positive and safe experience for
        everyone.
      </p>

      <h3 className="header">Be Respectful</h3>
      <p className="text">
        Treat others with respect, kindness, and empathy. Refrain from using
        offensive language, engaging in personal attacks, or any behavior that
        may harm or disrespect others. We celebrate diversity and encourage
        open-mindedness, valuing the contributions of all individuals regardless
        of their backgrounds.
      </p>

      <h3 className="header">Foster a Safe Environment</h3>
      <p className="text">
        Learnify is committed to providing a safe and harassment-free space for
        all participants. Harassment or discrimination based on race, gender,
        sexual orientation, religion, disability, or any other personal
        characteristic will not be tolerated. Respect personal boundaries and
        obtain consent before engaging in direct communication.
      </p>

      <h3 className="header">Share Knowledge and Ideas</h3>
      <p className="text">
        Learnify thrives on the exchange of knowledge and ideas. Share your
        expertise and insights constructively, promoting a supportive learning
        environment. Encourage constructive feedback and be open to learning
        from others.
      </p>

      <h3 className="header">Maintain Integrity</h3>
      <p className="text">
        Be truthful and honest in your interactions on Learnify. Plagiarism,
        cheating, or any form of dishonesty undermines the spirit of learning
        and will not be tolerated.
      </p>

      <h3 className="header">Report Concerns</h3>
      <p className="text">
        If you encounter any behavior that violates this Code of Conduct or feel
        uncomfortable with any interaction, please report it to the Learnify
        team immediately. We are committed to addressing and resolving any
        concerns promptly and confidentially.
      </p>

      <h3 className="header">Consequences of Violations</h3>
      <p className="text">
        Violations of this Code of Conduct may result in warnings, temporary
        suspension, or permanent expulsion from Learnify, depending on the
        severity and frequency of the behavior. We reserve the right to take
        appropriate actions to maintain a positive and inclusive learning
        community.
      </p>

      <h3 className="header">Conclusion</h3>
      <p className="text">
        By being part of Learnify, you agree to abide by this Code of Conduct
        and contribute to creating a positive, inclusive, and supportive
        learning environment for all participants. Let's learn from each other
        and grow together as a community.
      </p>
    </motion.div>
  );
};

export default CodeOfConductPage;
