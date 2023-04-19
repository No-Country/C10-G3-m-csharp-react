
import Link from "next/link"
import Header from "../../scss/views/Header/Header.module.scss"
import LupaHeader from "../LupaSvg/Lupa"
import MapaHeader from "../MapaSvg/Mapa"

export default function Buscador() {
    return (
        <>
            <form className={Header.form}>
                <label htmlFor="text">
                    <input
                        id="text"
                        className={Header.Search}
                        type="text"
                        placeholder="Buscar establecimiento" />
                </label>
                <div className={Header.lupa}>
                    <LupaHeader />
                </div>
            </form>
            <div className={Header.mapa}>
                <div>
                    <MapaHeader />

                </div>
                <Link href="/" className={Header.mapa__letter}> Buscar en el mapa </Link>
            </div>
        </>
    )
}