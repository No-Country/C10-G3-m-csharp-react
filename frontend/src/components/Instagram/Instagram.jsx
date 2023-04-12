import Footer from "../../scss/views/Footer/Footer.module.scss"

export default function isInstagram () {
    return(
        <div className={Footer.isContainer}>
            <i class='bx bxl-instagram-alt bx-sm'></i>
        </div>
    )
}