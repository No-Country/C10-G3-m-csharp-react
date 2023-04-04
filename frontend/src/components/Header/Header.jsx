import Header from "../../scss/views/Header/Header.module.scss"
import Image from "next/image"
import Navbar from "../Navbar/Navbar"
import Link from "next/link"
import LogoHeader from "../HeaderLogo/HeaderSvg"
import LupaHeader from "../LupaSvg/Lupa"
import MapaHeader from "../MapaSvg/Mapa"

export default function isHeader() {
    return (
        <header className={Header.headerContainer}>
            <div className={Header.Container}>
                <div className={Header.Container__Dates}>
                    <div>
                        <LogoHeader/>
                    </div>
                </div>
                <div className={Header.Texto}>
                    <h1 className={Header.Texto__Welcome}> Hola Pedro Pascal </h1>
                    <h2 className={Header.Texto__date}>Viernes 24 de marzo</h2>
                </div>
                <Navbar />
            </div>

            <form className={Header.form}>
                <label htmlFor="text">
                    <input
                        id="text"
                        className={Header.Search}
                        type="text"
                        placeholder="Buscar establecimiento" />
                </label>
                <div className={Header.lupa}>
                <LupaHeader/>
                </div>
            </form>
            <div className={Header.mapa}>
                <div>
                <MapaHeader/>

                </div>
                <Link href="/" className={Header.mapa__letter}> Buscar en el mapa </Link>
            </div>


        </header>

    )
}