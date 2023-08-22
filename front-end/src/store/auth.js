import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  userRole: "guest",
  userSignedIn: false,
};

const auth = createSlice({
  name: "auth",
  initialState,
  reducers: {
    loginUser: (state, action) => {
      state.userSignedIn = true;
      state.userRole = action.payload;
    },
  },
});

export const { loginUser } = auth.actions;
export default auth.reducer;
