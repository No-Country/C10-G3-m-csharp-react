import Header from "../../scss/views/Header/Header.module.scss"
import Image from "next/image"
import Navbar from "../Navbar/Navbar"
import Link from "next/link"
export default function isHeader() {
    return (
        <header className={Header.headerContainer}>
            <div className={Header.Container}>
                <div className={Header.Container__Dates}>
                   
                    <div className={Header.fingers}>
                        <Image className={Header.fingers2} width={7} height={4.82} src="/images/Vector2.svg" alt="fingers"/>
                        <Image width={6.5} height={12.14} src="/images/Vector3.svg" alt="fingers"/>
                        <Image width={6.5} height={16.96} src="/images/Vector4.svg" alt="fingers"/>
                        <Image width={6.5} height={8.87} src="/images/Vector5.svg" alt="fingers"/>
                    </div>

                    <div className={Header.love}>
                        <Image width={40} height={26.32} src="/images/Vector1.svg" alt="love" />
                    </div>

                    <div className={Header.silla}>
                        <Image className={Header.cabeza} width={8} height={3.22} src="/images/Vector8.svg" alt="cabeza" />
                        <Image width={10} height={8.75} src="/images/Vector6.svg" alt="cuerpo" />
                        <Image className={Header.rueda} width={14} height={10.42} src="/images/Vector7.svg" alt="rueda" />
                    </div>
                    <div className={Header.mano}>
                        <Image width={40} height={28.94} src="/images/Vector9.svg" alt="mano" />
                        <Image width={55} height={14.23} src="/images/Inclusive.svg" alt="inclusive" />

                    </div>
                </div>
                <div className={Header.Texto}>
                    <h1 className={Header.Texto__Welcome}> Hola Pedro Pascal </h1>
                    <h2 className={Header.Texto__date}>Viernes 24 de marzo</h2>
                </div>
               <Navbar/>
            </div>

            <form className={Header.form}>
                <label htmlFor="text">
                <input 
                id="text"
                className={Header.Search} 
                type="text"
                 placeholder="Buscar establecimiento"/>
                </label>
                <Image className={Header.lupa} width={17.48} height={17.48} src="./images/search.svg" alt="lupa"/>
            </form>
            <div className={Header.mapa}>
               <Image width={13.97} height={19.97} src="./images/place.svg" alt="mapa"/>
               <Link href="/" className={Header.mapa__letter}> Buscar en el mapa </Link>
              </div>

           
        </header>

    )
}