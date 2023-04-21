import { createAsyncThunk } from "@reduxjs/toolkit";

let endpoint =
  "https://inclusive-001-site1.atempurl.com/api/Authentication/register";

export const registerUser = createAsyncThunk("register", async (userInfo) => {
  try {
    console.log("Ingresando a RegisterUser");

    const data = (await axios.post(`${BASE_URL}/user`, userInfo)).data;
    console.log(data);
    return data;
  } catch (e) {
    if (e.response && e.response.data.message) {
      //console.log(e)
      return e.response.data.message;
    } else {
      return e.message;
    }
  }
});
