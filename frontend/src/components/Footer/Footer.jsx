import Footer from "../../scss/views/Footer/Footer.module.scss"
import HeaderSvg from "../HeaderLogo/HeaderSvg"
import Facebook from "../Facebook/Facebook"
import Twiter from "../Twiter/Twiter"
import Instagram from "../Instagram/Instagram"

export default function isFooter() {
    return (
        <footer className={Footer.Container}>
            <div className={Footer.Container__img}>
                <HeaderSvg />
            </div>
            <div className={Footer.Container__texto}>
                <h4 className={Footer.Container__TextoComplait}>
                    Preguntas frecuentes
                    Terminos y condiciones
                    Politica de Privacidad
                    Contacto

                </h4>
                <div className={Footer.RedesSociales}>


                    <section>
                        <Instagram />
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