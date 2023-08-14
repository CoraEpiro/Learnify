import LastListings from "../last-listings/index.js";

const LastQuestions = () => {
  const questions = [
    {
      title: "What you learning about this weekend?",
      url: "/",
      description: "11 comments",
    },
    {
      title: "How Did You Bounce Back from Failed Coding Attempts?",
      url: "/",
      description: "4 comments",
    },
    {
      title: "Share Your Secrets for Staying Connected with Colleagues",
      url: "/",
      description: "8 comments",
    },
    {
      title:
        "Lonely vs. Connected: How Do You Balance Social Interaction in Remote Settings?",
      url: "/",
      description: "4 comments",
    },
    {
      title: "Who's looking for open source contributors? (week 54)",
      url: "/",
      description: "18 comments",
    },
  ];
  return (
    <div>
      <LastListings title={"Last Questions"} data={questions} seeAllUrl={"/"} />
    </div>
  );
};

export default LastQuestions;
