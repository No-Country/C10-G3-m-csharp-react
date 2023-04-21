import Header from "../../scss/views/Header/Header.module.scss";
import Image from "next/image";
import Navbar from "../Navbar/Navbar";
import Link from "next/link";
import LogoHeader from "../HeaderLogo/HeaderSvg";
import LupaHeader from "../LupaSvg/Lupa";
import MapaHeader from "../MapaSvg/Mapa";

import { useRouter } from "next/router";
import { useEffect, useState } from "react";

export default function IsHeader() {
  const router = useRouter();

  const date = new Date();

  const months = [
    "Enero",
    "Febrero",
    "Marzo",
    "Abril",
    "Mayo",
    "Junio",
    "Julio",
    "Agosto",
    "Septiembre",
    "Octubre",
    "Noviembre",
    "Diciembre",
  ];
  const days = [
    "Domingo",
    "Lunes",
    "Martes",
    "Miercoles",
    "Jueves",
    "Viernes",
    "Sabado",
  ];

  const displayDate = `${days[date.getDay()]} ${date.getDate()} de ${
    months[date.getMonth()]
  }`;

  const [displayName, setdisplayName] = useState("Extraño");

  useEffect(() => {
    const user = localStorage.getItem("userToken");

    if (user) {
      function parseJwt(token) {
        var base64Url = token.split(".")[1];
        var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
        var jsonPayload = decodeURIComponent(
          window
            .atob(base64)
            .split("")
            .map(function (c) {
              return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
            })
            .join("")
        );

        return JSON.parse(jsonPayload);
      }

      const userName = parseJwt(user);

      setdisplayName(userName.name);
    } else {
      return;
    }
  }, []);

  return (
    <header className={Header.headerContainer}>
      <div className={Header.Container}>
        <div className={Header.Container__Dates}>
          <div>
            <Link href="/landing">
              <LogoHeader />
            </Link>
          </div>
        </div>
        <div className={Header.Texto}>
          <h1 className={Header.Texto__Welcome}> Hola {displayName} </h1>
          <h2 className={Header.Texto__date}>{displayDate}</h2>
        </div>
        <Navbar />
      </div>

      <form
        className={Header.form}
        onSubmit={(e) => {
          e.preventDefault();
          router.push(`/search?term=${e.target[0].value}`)
        }}
      >
        <label htmlFor="text">
          <input
            id="text"
            className={Header.Search}
            type="text"
            placeholder="Buscar establecimiento"
          />
        </label>
        <div className={Header.lupa}>
          <LupaHeader />
        </div>
      </form>
      <div className={Header.mapa}>
        <div>
          <MapaHeader />
        </div>
        <Link href="/" className={Header.mapa__letter}>
          {" "}
          Buscar en el mapa{" "}
        </Link>
      </div>
    </header>
  );
}
