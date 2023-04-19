import React from "react";
import styles from "../../scss/views/barrel_views.module.scss";
import Image from "next/image";
import Logo from "../../../public/img/loginSingIn/Logo.png";
import Button from "@/components/Buttons/Button";
import Link from "next/link";

const { container, loginImageCenter, loginButtonsContainer, linksWrapper } =
  styles;

export default function index() {
  return (
    <div className={container}>
      <Image src={Logo} className={loginImageCenter} alt="" />

      <div className={loginButtonsContainer}>
        <Link href="/signIn">
          <Button value="Ingresar" />
        </Link>
        <Link href="/register">
          <Button value="Deseo registrarme" />
        </Link>
      </div>
    </div>
  );
}
