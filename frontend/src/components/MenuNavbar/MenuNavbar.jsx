import LogoHeader from "../HeaderFooter/HeaderFooter";
import Navbar from "../Navbar/Navbar";
import Header from "../../scss/views/Header/Header.module.scss"

export default function MenuNavbar(){
    return(
        <>        
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
        <Navbar/>
    </div>
    </>
    )
}