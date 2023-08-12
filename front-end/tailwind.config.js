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
        "hover-blue-clr": "#ebecfc",
        accent: "#3B49DF",
        "second-text": "#cbc7c0",
        "dark-text": "#aaa398",
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
