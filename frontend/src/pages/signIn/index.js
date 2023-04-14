import React from "react";
import Logo from '../../../public/img/loginSingIn/Logo.png';
import Image from "next/image";
import styles from "../../scss/views/barrel_views.module.scss";
import Button from "@/components/Buttons/Button";
import Blockline from "../../../public/img/loginSingIn/Blockline.png"
import GoogleButton from "@/components/Buttons/GoogleButton";
import AppleButton from "@/components/Buttons/AppleButton";

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
  fastSignInButtonsCtn
} = styles;

export default function index() {
  return (
    <div className={container}>
      <div className={logoAndTitleContainer}>
        <Image src={Logo} className={signInLogoSized} alt="" />
        <h4 className={signInTitleBold}>INICIAR SESIÓN</h4>
      </div>
      <div className={inputContainer}>
        <input
          type="text"
          placeholder="Correo electrónico"
          className={signInInputOutlined}
        />
        <input
          type="text"
          placeholder="Contraseña"
          className={signInInputOutlined}
        />
      </div>
      <div className={signInBoxRestoreAndButton}>
        <h5 className={subTitleh5}>¿Olvidó su contraseña?</h5>
        <Button value="Ingresar" />
      </div>
      <Image src={Blockline} alt="blockline" />

      <div className={signInFastContainer}>
        <h5 className={subTitleh5}>Inicia sesión con:</h5>
        <div className={fastSignInButtonsCtn}>
          <GoogleButton />
          <AppleButton />
        </div>
      </div>
    </div>
  );
}
