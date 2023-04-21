import LogoHeader from "../HeaderFooter/HeaderFooter";
import Navbar from "../Navbar/Navbar";
import Header from "../../scss/views/Header/Header.module.scss"
import { useRouter } from "next/router";
import { useEffect, useState } from "react";
import Link from "next/link";

export default function MenuNavbar(){

    const router = useRouter();

    
    const date = new Date()
    const dias = ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'];
    const mes = ['Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre',]

    const displayDate = `${dias[date.getDay()]} ${date.getDate()} de
    ${mes[date.getMonth()]}`;

    const [displayUser , setDisplayUser] = useState("Extraño");

    useEffect(() => {
        const users = localStorage.getItem("userToken")

        if (users) {
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
      
            const userName = parseJwt(users);
      
            setDisplayUser(userName.name);
    } else{
        return
    }
    
},[])

console.log(displayUser)

    return(
        <>        
        <div className={Header.Container}>
        <div className={Header.Container__Dates}>
            <div>
                <Link href="/landing">
                <LogoHeader/>
                </Link>
            </div>
        </div>
        <div className={Header.Texto}>
            <h1 className={Header.Texto__Welcome}> Hola {displayUser} </h1>
            <h2 className={Header.Texto__date}> {displayDate} </h2>
        </div>
        <Navbar/>
    </div>
    </>
    )
}