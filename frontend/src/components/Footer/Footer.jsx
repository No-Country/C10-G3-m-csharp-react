import Footer from "../../scss/views/Footer/Footer.module.scss"
import HeaderFooter from "../HeaderFooter/HeaderFooter"
import Facebook from "../Facebook/Facebook"
import Twiter from "../Twiter/Twiter"
import Instagram from "../Instagram/Instagram"
import Link from "next/link"

export default function isFooter() {
    return (
        
        <footer className={Footer.Container}>
           
            <div className={Footer.Container__img}>
                <HeaderFooter/>
            </div>
            <div className={Footer.Container__texto}>
                <h4 className={Footer.Container__TextoComplait}>
                    <Link href="/frequent">
                    Preguntas frecuentes
                    </Link> 
                    Terminos y condiciones
                    Politica de Privacidad
                    Contacto

                </h4>
                
            </div>
                <div className={Footer.RedesSociales}>

                     <div className={Footer.Redes}> 
                    <section>
                        <Instagram/>
            
                    </section>
                    <section>
                        <Twiter />
                    </section>

                    <section>
                        <Facebook />
                    </section>
                    </div>

                    <div className={Footer.Copyrigth}>
                      
                      <div>
                      <i className='bx bx-copyright' ></i>
                      </div>
                      <h4>
                        2023 Inclusive Inc
                      </h4>
                  
                    </div>


                </div>

              

        </footer>
    )
}