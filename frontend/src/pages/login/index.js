import React from "react";
import styles from "../../scss/views/barrel_views.module.scss";
import Image from "next/image";
import Logo from '../../../public/img/loginSingIn/Logo.png';
import Button from "@/components/Buttons/Button";

const { container, loginImageCenter,loginButtonsContainer } = styles;

export default function Login() {
  return (
    <div className={container}>
      <Image src={Logo} className={loginImageCenter} alt="" />

      <div className={loginButtonsContainer}>
        <Button value='Ingresar'/>
        <Button value='Deseo registrarme'/>
      </div>
    </div>
  );
}
