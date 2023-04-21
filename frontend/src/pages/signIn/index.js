import React from "react";
import Logo from "../../../public/img/loginSingIn/Logo.png";
import Image from "next/image";
import styles from "../../scss/views/barrel_views.module.scss";
import Button from "@/components/Buttons/Button";
import Blockline from "../../../public/img/loginSingIn/Blockline.png";
import GoogleButton from "@/components/Buttons/GoogleButton";
import AppleButton from "@/components/Buttons/AppleButton";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useRouter } from "next/router";




const {
  container,
  signInLogoSized,
  signInTitleBold,
  logoAndTitleContainer,
  inputContainer,
  signInInputOutlined,
  subTitleh5,
  signInBoxRestoreAndButton,
  signInFastContainer,
  fastSignInButtonsCtn,
  errorMsg,
} = styles;

const schema = yup
  .object({
    email: yup
      .string()
      .required("Este campo es obligatorio")
      .email("Debe ser un formato válido"),
    password: yup.string().required("Este campo es obligatorio"),
  })
  .required();

export default function SignIn() {

  
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm({
    resolver: yupResolver(schema),
  });

  const router = useRouter();

  const onSubmit = async (data) => {


    console.log(data);   

    let endpoint =
      "https://inclusive-001-site1.atempurl.com/api/Authentication/login";

    let response = await fetch(endpoint, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
    

    console.log(response.status)    
     
    let token = response.json();  

    token
      .then((data) => {
        localStorage.setItem("userToken", JSON.stringify(data.token));
        console.log(data)
        router.push("/")                
  })}

  return (
    <div className={container}>
      <div className={logoAndTitleContainer}>
        <Image src={Logo} className={signInLogoSized} alt="logo" />
        <h4 className={signInTitleBold}>INICIAR SESIÓN</h4>
      </div>
      <form className={inputContainer} onSubmit={handleSubmit(onSubmit)}>
        <input
          {...register("email")}
          type="text"
          placeholder="Correo electrónico"
          className={signInInputOutlined}
        />
        {errors.email && <div className={errorMsg}>{errors.email.message}</div>}
        <input
          {...register("password")}
          type="password"
          placeholder="Contraseña"
          className={signInInputOutlined}
        />

        {errors.password && (
          <div className={errorMsg}>{errors.password.message}</div>
        )}

        <div className={signInBoxRestoreAndButton}>
          <h5 className={subTitleh5}>¿Olvidó su contraseña?</h5>
          <Button value="Ingresar" type="submit" />
        </div>
      </form>

      <Image src={Blockline} alt="blockline" />

      <div className={signInFastContainer}>
        <h5 className={subTitleh5}>Inicia sesión con:</h5>
        <div className={fastSignInButtonsCtn}>
          <GoogleButton />
          <AppleButton />
        </div>
      </div>
    </div>
  )}