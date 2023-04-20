import React, { useState } from "react";
import Logo from "../../../public/img/loginSingIn/Logo.png";
import Image from "next/image";
import styles from "../../scss/views/barrel_views.module.scss";
import Button from "@/components/Buttons/Button";
import Blockline from "../../../public/img/loginSingIn/Blockline.png";
import GoogleButton from "@/components/Buttons/GoogleButton";
import Eye from "../../../public/images/eye.png";
import EyeOff from "../../../public/images/eye-off.png";
import AppleButton from "@/components/Buttons/AppleButton";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import Link from "next/link";
import { useRouter } from "next/router";
import { userAgent } from "next/server";

const {
  container,
  logoAndTitleContainer,
  signInLogoSized,
  signInTitleBold,
  signInFastContainer,
  subTitleh5,
  fastSignInButtonsCtn,
  signInInputOutlined,
  inputContainer,
  termsBox,
  checkRounded,
  errorMsg,
  pswInputContainer,
  reveal_psw,
  pswInput,
} = styles;

const schema = yup
  .object({
    firstName: yup.string().required("Este campo es obligatorio"),
    lastName: yup.string().required("Este campo es obligatorio"),
    email: yup.string().required().email("Debe ser un formato válido"),
    userName: yup
      .string()
      .required("Este campo es obligatorio")
      .min(6, "Debe tener un mínimo 6 carácteres"),
    password: yup
      .string()
      .min(6, "Mínimo 6 carácteres")
      .required("Este campo es obligatorio"),
    repeat_password: yup
      .string()
      .oneOf([yup.ref("password"), null], "Las contraseñas no coinciden")
      .required("Campo Obligatorio"),
  })
  .required();

export default function register() {
  const router = useRouter();

  const [passwordImage, setPasswordImage] = useState({
    src: EyeOff,
    alt: "EyeOff",
  });

  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data) => {

    console.log(data);

    let userData = {
      "firstName": data.firstName ,
      "lastName": data.lastName,
      "email": data.email,
      "userName": data.userName,
      "password": data.repeat_password
    }

    let endpoint =
      "https://inclusive-001-site1.atempurl.com/api/Authentication/register";

    let response = await fetch(endpoint, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userData),
    })

    let responseStatus = response.status;

    responseStatus === 201
    ? (router.push("/signIn"))
    : (console.log('Usuario no autorizado'))    
  };

  const changeTypeAndImg = () => {
    let pswInput = document.getElementById("pswInput");
    let pswInput2 = document.getElementById("pswInput2");

    pswInput.type === "password"
      ? ((pswInput.type = "text"),
        (pswInput2.type = "text"),
        setPasswordImage({
          src: Eye,
          alt: "Mostrar contraseña",
        }))
      : ((pswInput.type = "password"),
        (pswInput2.type = "password"),
        setPasswordImage({
          src: EyeOff,
          alt: "Ocultar contraseña",
        }));
  };

  return (
    <div className={container}>
      <div className={logoAndTitleContainer}>
        <Image src={Logo} className={signInLogoSized} alt="" />
        <h4 className={signInTitleBold}>REGISTRO</h4>
      </div>
      <div className={signInFastContainer}>
        <h5 className={subTitleh5}>Registrate con tu cuenta de:</h5>
        <div className={fastSignInButtonsCtn}>
          <GoogleButton />
          <AppleButton />
        </div>
      </div>
      <Image src={Blockline} alt="blockline" />
      <div>
        <h5 className={subTitleh5}>Llena el formulario de registro</h5>
        <form className={inputContainer} onSubmit={handleSubmit(onSubmit)}>
          <input
            {...register("firstName")}
            aria-invalid={errors.name ? "true" : "false"}
            type="text"
            placeholder="Nombre"
            className={signInInputOutlined}
          />
          {errors.firstName && (
            <div className={errorMsg}>{errors.firstName.message}</div>
          )}
          <input
            {...register("lastName")}
            type="text"
            placeholder="Apellidos"
            className={signInInputOutlined}
          />
          {errors.lastName && (
            <div className={errorMsg}>{errors.lastName.message}</div>
          )}

          <input
            {...register("email")}
            type="text"
            placeholder="Correo electrónico"
            className={signInInputOutlined}
          />
          {errors.email && (
            <div className={errorMsg}>{errors.email.message}</div>
          )}

          <input
            {...register("userName")}
            type="text"
            placeholder="Nombre de usuario"
            className={signInInputOutlined}
          />
          {errors.userName && (
            <div className={errorMsg}>{errors.userName.message}</div>
          )}
          <div className={pswInputContainer}>
            <input
              {...register("password")}
              type="password"
              placeholder="Contraseña"
              className={pswInput}
              id="pswInput"
            ></input>
            <Image
              src={passwordImage.src}
              className={reveal_psw}
              alt={passwordImage.alt}
              id="revealEye"
              onClick={changeTypeAndImg}
            />
          </div>

          {errors.password && (
            <div className={errorMsg}>{errors.password.message}</div>
          )}

          <div className={pswInputContainer}>
            <input
              {...register("repeat_password")}
              type="password"
              placeholder="Repetir constraseña"
              className={pswInput}
              id="pswInput2"
            ></input>
            <Image
              src={passwordImage.src}
              className={reveal_psw}
              alt={passwordImage.alt}
              onClick={changeTypeAndImg}
            />
          </div>
          {errors.repeat_password && (
            <div className={errorMsg}>{errors.repeat_password.message}</div>
          )}

          <div className={termsBox}>
            <input
              type="radio"
              id="Acepto los terminos y condiciones"
              className={checkRounded}
              {...register("terms")}
            />
            <label htmlFor="Acepto los terminos y condiciones">
              Acepto los terminos y condiciones
            </label>
          </div>
          {/* <Link href="./signIn"> */}
          <Button type="submit" value="Aceptar" />
          {/* </Link> */}
        </form>
      </div>
    </div>
  );
}
