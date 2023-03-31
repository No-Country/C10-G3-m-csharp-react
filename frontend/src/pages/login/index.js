import React from "react";
import styles from "../../scss/views/barrel_views.module.scss";
import Image from "next/image";
import Logo from "../.././../public/Logo.png";
import Button from "@/components/Buttons/Button";

const { container, loginImageCenter, loginButtonOutlined,loginButtonsContainer } = styles;

export default function Login() {
  return (
    <div className={container}>
      <Image src={Logo} className={loginImageCenter} />

      <div className={loginButtonsContainer}>
        <Button value='Ingresar'/>
        <Button value='Deseo registrarme'/>
      </div>
    </div>
  );
}
