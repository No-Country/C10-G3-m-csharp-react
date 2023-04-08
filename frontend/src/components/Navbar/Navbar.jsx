import React, { useState } from "react";
import Image from "next/image"
import Link from "next/link";

export default function Navbar() {
    const [isopen, setIsopen] = useState(false)
   
    const Cambio = () => {
        setIsopen(!isopen)
    }

      return (
        <div className="Container">
            <div className={`Cortina ${isopen && "remove"}`}></div>
            <div className={`Toggle ${isopen && "open"}`} onClick={Cambio} >
                <Image className="Hamburger" width={32} height={20} src="./images/Hamburguesa.svg" alt="Hamburguesa" />
            </div>

            <div className={`items ${isopen && "open"}`}>
            </div>
            
                <div className={`CloseClose  ${isopen && "open"} `}  onClick={Cambio}  > 
                <div className={`ContainerClose ${isopen && "open"}`} onClick={Cambio} >
                    <Image className="Close" width={18.63} height={18.63} src="./images/close.svg" alt="close" />
                </div>
               
                  <ul className="itemsListas">
                    <li>
                       <Link href="/"> Perfil de usuario </Link>

                    </li>
                    <li>
                        <Link href="/"> Lugares Destacados </Link>

                    </li>
                    <li>
                        <Link href="/"> Preguntas Frecuentes </Link>

                    </li>
                    <li>
                        <Link href="/"> Registra tu local </Link>

                    </li>
                    <li className="Ayuda">
                      <Link href="/"> Ayuda </Link>

                    </li>
                    
                    <li>
                        <Link href="/"> Cerrar sesión </Link>
                    </li>
                </ul>
                </div>
                
         
           

        </div>

    )
}