import Link from "next/link";
import styles from "../../scss/views/Landing/Landing.module.scss";
import Image from "next/image";
import InclusiveLogo from "@/components/inclusiveLogo/inclusiveLogo";

function Landing() {
  return (
    <div>
      <header className={styles.header}>
        <div className={styles.logoContainer}>
          <InclusiveLogo width={121} height={146} />
        </div>
        <div className={styles.auth}>
          <Link href="/">Login/<br/>Registro</Link>
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
        <section></section>
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
