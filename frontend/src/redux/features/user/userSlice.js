import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  firstName: "",
  lastName: "",
  email: "",
  userName: "",
  password: "",
};

export const registerSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    cleanRegister: (state) => (state = initialState),
  },
});

export const { cleanRegister } = registerSlice.actions;
