import LastListings from "../last-listings/index.js";

const LastArticles = () => {
  const articles = [
    {
      title: "How to Sеt Up and Usе PostgrеSQL with Dockеr",
      url: "/",
      description: "#webdev  javascript  #node  #tutorial",
    },
    {
      title: "Supercharge Your Flutter Workflow Using 7 Pro Tools 🚀",
      url: "/",
      description: "#webdev  javascript  #node  #tutorial",
    },
    {
      title: "Advancеd Quеrying Tеchniquеs in PostgrеSQL",
      url: "/",
      description: "#webdev  javascript  #node  #tutorial",
    },
    {
      title: "Advancеd Quеrying Tеchniquеs in PostgrеSQL",
      url: "/",
      description: "#webdev  javascript  #node  #tutorial",
    },
  ];
  return (
    <div>
      <LastListings title={"Last Articles"} data={articles} seeAllUrl={"/"} />
    </div>
  );
};

export default LastArticles;
