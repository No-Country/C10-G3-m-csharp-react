import React from "react";
import Logo from '../../../public/img/loginSingIn/Logo.png';
import Image from "next/image";
import styles from "../../scss/views/barrel_views.module.scss";
import Button from "@/components/Buttons/Button";
import Blockline from '../../../public/img/loginSingIn/Blockline.png'
import GoogleButton from "@/components/Buttons/GoogleButton";
import AppleButton from "@/components/Buttons/AppleButton";

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
} = styles;

export default function Register() {
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

        <form className={inputContainer}>
          <input
            type="text"
            placeholder="Nombre"
            className={signInInputOutlined}
          />
          <input
            type="text"
            placeholder="Apellidos"
            className={signInInputOutlined}
          />
          <input
            type="text"
            placeholder="Correo electrónico"
            className={signInInputOutlined}
          />
          <input
            type="text"
            placeholder="Nombre de usuario"
            className={signInInputOutlined}
          />
          <input
            type="password"
            placeholder="Contraseña"
            className={signInInputOutlined}
          />
          <input
            type="password"
            placeholder="Repetir contraseña"
            className={signInInputOutlined}
          />
          <div className={termsBox}>
            <input
              type="radio"
              id="Acepto los terminos y condiciones"
              className={checkRounded}
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
