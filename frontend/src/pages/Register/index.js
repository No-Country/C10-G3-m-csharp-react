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

export default function Register() {
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmit = (data) => {

    console.log(data);

    let endpoint =
      "https://inclusive-001-site1.atempurl.com/api/Authentication/register";    
      fetch(endpoint, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })      
    };

    
  

  return (
    <div className={container}>
      <div className={logoAndTitleContainer}>
        <Image src={Logo} className={signInLogoSized} />
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
          <input
            {...register("password")}
            type="password"
            placeholder="Contraseña"
            className={signInInputOutlined}
          />
          {errors.password && (
            <div className={errorMsg}>{errors.password.message}</div>
          )}

          <input
            {...register("repeat_password")}
            type="password"
            placeholder="Repetir contraseña"
            className={signInInputOutlined}
          />
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
            <label for="Acepto los terminos y condiciones">
              Acepto los terminos y condiciones
            </label>
          </div>
          <Button type="submit" value="Aceptar" />
        </form>
      </div>
    </div>
  );
}
