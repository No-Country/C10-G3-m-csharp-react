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
    name: yup.string().required("Este campo es obligatorio"),
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
      .oneOf([yup.ref("password"), null], "Las contraseñas no  coinciden")
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

  const onSubmit = (data) => console.log(data);

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
            {...register("name")}
            aria-invalid={errors.name ? "true" : "false"}
            type="text"
            placeholder="Nombre"
            className={signInInputOutlined}
          />
          {errors.name && <div className={errorMsg}>{errors.name.message}</div>}
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

/* 

<form className={inputContainer} onSubmit={handleSubmit(onSubmit)}>
          <input
            {...register("name", {
              required: {
                value: true,
                message: "El nombre es requerido",
              },
              minLength: {
                value: 6,
                message: "Debe tener al menos 6 carácteres",
              },
            })}
            aria-invalid={errors.name ? "true" : "false"}
            type="text"
            placeholder="Nombre"
            className={signInInputOutlined}
          />
          {errors.name && (
            <div className={errorMsg}>
              {errors.name.message}
            </div>
          )}
          <input
            {...register("lastName", {
              required: {
                value: true,
                message: "El apellido es requerido",
              },
              minLength: {
                value: 6,
                message: "Debe tener al menos 6 carácteres",
              },
            })}
            type="text"
            placeholder="Apellidos"
            className={signInInputOutlined}
          />
           {errors.lastName && (
            <div className={errorMsg}>
              {errors.lastName.message}
            </div>
          )}
          
          <input
            {...register("email",{
              pattern:{
                value:/^[a-zA-Z0-9]+@(?:[a-zA-Z0-9]+\.)+[A-Za-z]+$/,
                message: 'El formato es incorrecto'
                }
            }
            )}
            type="text"
            placeholder="Correo electrónico"
            className={signInInputOutlined}            
          />
             {errors.email && (
            <div className={errorMsg}>
              {errors.email.message}
            </div>
          )}
          
          <input
            {...register("userName")}
            type="text"
            placeholder="Nombre de usuario"
            className={signInInputOutlined}
          />
          <input
            {...register("password", {
              required: true,
              minLength: {
                value: 8,
                message: "La contraseña debe tener mínimo 8 carácteres",
              },
            })}
            type="password"
            placeholder="Contraseña"
            className={signInInputOutlined}
          />

          <input
            {...register("password2", {
              required: true,
              minLength: {
                value: 8,
                message: "La contraseña debe tener mínimo 8 carácteres",
              },
            })}
            type="password"
            placeholder="Repetir contraseña"
            className={signInInputOutlined}
          />
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

*/
