import { createAsyncThunk } from "@reduxjs/toolkit";
import { useRouter } from "next/router";

let endpoint =
  "https://inclusive-001-site1.atempurl.com/api/Authentication/register";

export const registerUser = createAsyncThunk("register", async (userData) => {
  const router = useRouter();
  try {
    console.log("Ingresando a RegisterUser");

    const response = await fetch(endpoint, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userData),
    });

    console.log(response.status);

    let responseStatus = response.status;

    responseStatus === 201 ? router.push("/signIn") : "Acá no ha llegado";
  } catch (e) {
    if (e.response && e.response.data.message) {
      //console.log(e)
      return e.response.data.message;
    } else {
      return e.message;
    }
  }
});
