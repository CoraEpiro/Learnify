import { Link } from "react-router-dom";

const Brand = () => {
  return (
    <Link to={"/"} className={"w-12 h-10"}>
      <img
        className={"rounded-lg w-12 h-10"}
        src="https://dev-to-uploads.s3.amazonaws.com/uploads/logos/resized_logo_UQww2soKuUsjaOGNB38o.png"
        alt="logo"
      />
    </Link>
  );
};

export default Brand;
