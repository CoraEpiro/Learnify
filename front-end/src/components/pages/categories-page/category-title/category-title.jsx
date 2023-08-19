import PropTypes from "prop-types";
import "./category-title.css";
import { useState } from "react";

const CategoryTitle = ({ title, color }) => {
  const generateColors = (hexColor) => {
    // generate rhb values from hex color
    const r = parseInt(hexColor.slice(1, 3), 16);
    const g = parseInt(hexColor.slice(3, 5), 16);
    const b = parseInt(hexColor.slice(5, 7), 16);

    // original color
    const originalColor = hexColor;

    // light version
    const lightFactor = 6;
    const lightR = Math.min(Math.floor(r * lightFactor), 255);
    const lightG = Math.min(Math.floor(g * lightFactor), 255);
    const lightB = Math.min(Math.floor(b * lightFactor), 255);
    const lightColor = `#${lightR.toString(16).padStart(2, "0")}${lightG
      .toString(16)
      .padStart(2, "0")}${lightB.toString(16).padStart(2, "0")}`;

    // dark version
    const darkFactor = 0.8;
    const darkR = Math.max(Math.floor(r * darkFactor), 0);
    const darkG = Math.max(Math.floor(g * darkFactor), 0);
    const darkB = Math.max(Math.floor(b * darkFactor), 0);
    const darkColor = `#${darkR.toString(16).padStart(2, "0")}${darkG
      .toString(16)
      .padStart(2, "0")}${darkB.toString(16).padStart(2, "0")}`;

    return {
      original: originalColor,
      light: lightColor,
      dark: darkColor,
    };
  };

  const colorVariations = generateColors(color);

  const [hover, setHover] = useState(false);

  const sectionStyle = {
    backgroundColor: hover ? colorVariations.light : "transparent",
    borderColor: hover ? colorVariations.dark : "transparent",
  };

  return (
    <>
      <button
        id={title}
        className={
          "category mx-[-8px] text-sm font-bold transition-all duration-70 rounded-md py-1 px-2 border"
        }
        onMouseEnter={() => setHover(true)}
        onMouseLeave={() => setHover(false)}
        style={sectionStyle}
      >
        <span style={{ color: colorVariations.original }}>#</span>
        <span className={"text-black"}>{title}</span>
      </button>
    </>
  );
};

CategoryTitle.propTypes = { title: PropTypes.string, color: PropTypes.string };

export default CategoryTitle;
