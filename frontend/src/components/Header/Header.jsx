import Header from "../../scss/views/Header/Header.module.scss"
import Buscador from "../Buscador/Buscador"
import MenuNavbar from "../MenuNavbar/MenuNavbar"

export default function isHeader() {
    return (
        <header className={Header.headerContainer}>
             <MenuNavbar/>
             <Buscador/>
        </header>

    )
}