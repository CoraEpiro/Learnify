import { configureStore } from "@reduxjs/toolkit";
import auth from "./auth.js";
import modal from "./modal.js";

const store = configureStore({
  reducer: {
    auth,
    modal,
  },
});

export default store;
