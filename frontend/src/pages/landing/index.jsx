import Link from "next/link";
import styles from "../../scss/views/Landing/Landing.module.scss";
import Image from "next/image";
import InclusiveLogo from "@/components/inclusiveLogo/inclusiveLogo";
import Img1 from "../../../public/img/landing/landing-img-1.png";
import SearchLogo from "@/components/searchLogo/searchLogo";

function Landing() {
  return (
    <div>
      <header className={styles.header}>
        <div className={styles.logoContainer}>
          <InclusiveLogo width={121} height={146} />
        </div>
        <div className={styles.auth}>
          <Link href="/login">
            Login/
            <br />
            Registro
          </Link>
        </div>
        <nav className={styles.navbar}>
          <ul>
            <li>
              <Link href="/">Categorias de lugares</Link>
            </li>
            <li>
              <Link href="/">Quienes somos</Link>
            </li>
            <li>
              <Link href="/">Contacto</Link>
            </li>
            <li>
              <Link href="/">Preguntas Frecuentes</Link>
            </li>
          </ul>
        </nav>
      </header>

      <div>
        <section className={styles.welcome}>
          <Image
            src={Img1}
            width={360}
            height={278}
            alt="person in a wheelchair"
            priority
          />
          <div className={styles.form}>
            <input type="text" placeholder="Buscar lugares accesibles" />
            <SearchLogo/>
          </div>

          <h1>Bienvenidos a INCLUSIVE</h1>
        </section>
        <section></section>
        <section></section>
        <section></section>
        <section></section>
        <section></section>
      </div>
    </div>
  );
}

export default Landing;