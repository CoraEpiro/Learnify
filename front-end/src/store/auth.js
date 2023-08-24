import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  email: "",
  userRole: "guest",
  isProfileBuilt: undefined,
  userSignedIn: false,
};

const auth = createSlice({
  name: "auth",
  initialState,
  reducers: {
    setUser: (state, action) => {
      state.userSignedIn = true;
      state.userRole = action.payload.result.role;
      state.userEmail = action.payload.result.email;
      state.userProfileIsBuilt = action.payload.result.isProfileBuilt;
      if (action.payload.rememberMe) {
        localStorage.setItem("authToken", action.payload.result.token);
      } else {
        sessionStorage.setItem("authToken", action.payload.result.token);
      }
    },
  },
});

export const { loginUser } = auth.actions;
export default auth.reducer;
