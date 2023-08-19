import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./components/app/index.js";
import { Provider } from "react-redux";
import store from "src/store";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>
);
