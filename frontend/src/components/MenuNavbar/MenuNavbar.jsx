import LogoHeader from "../HeaderFooter/HeaderFooter";
import Navbar from "../Navbar/Navbar";
import Header from "../../scss/views/Header/Header.module.scss"

export default function MenuNavbar(){

    const dias = ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'];
    const mes = ['Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre',]
    const date = new Date()

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
            <h2 className={Header.Texto__date}>{`${dias[date.getDay()]} ${date.getDay()} de ${mes[date.getMonth()]}`}</h2>
        </div>
        <Navbar/>
    </div>
    </>
    )
}