/** @type {import('tailwindcss').Config} */
import withMT from "@material-tailwind/react/utils/withMT";

export default withMT({
  content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      colors: {
        "body-bg": "#f5f5f5",
        "border-clr": "#dfdfdf",
        "hover-border-clr": "#a3a3a3",
        "hover-bg-clr": "#ececec",
        "hover-blue-clr": "#ebecfc",
        accent: "#3B49DF",
        "accent-dark": "#2f3ab2",
        "second-text": "#575757",
        "dark-text": "#717171",
        "github-bg": "#24292e",
        "github-hover-bg": "#000000",
        "google-bg": "#24292e",
        "google-hover-bg": "#000000",
        "build-selected-category-bg": "#ebedfc",
      },
    },
  },
  plugins: [],
});
