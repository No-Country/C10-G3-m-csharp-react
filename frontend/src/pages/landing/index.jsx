import Link from "next/link";
import styles from "../../scss/views/Landing/Landing.module.scss";
import Image from "next/image";
import InclusiveLogo from "@/components/inclusiveLogo/inclusiveLogo";
import Img1 from "../../../public/img/landing/landing-img-1.png";
import Img2 from "../../../public/img/landing/landing-img-2.png";
import Img3 from "../../../public/img/landing/landing-img-3.png";
import Img4 from "../../../public/img/landing/landing-img-4.png";
import SearchLogo from "@/components/searchLogo/searchLogo";
import RightArrowLogo from "@/components/rightArrowLogo/rightArrowLogo";
import TopTenCardList from "@/components/topTenCardList/topTenCardList";

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
              <Link href="/contact">Contacto</Link>
            </li>
            <li>
              <Link href="/faq">Preguntas Frecuentes</Link>
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
            <SearchLogo />
          </div>

          <h1>Bienvenidos a INCLUSIVE</h1>
        </section>

        <section className={styles.intro}>
          <div className={styles.intro_img}>
            <Image
              src={Img2}
              width={312}
              height={200}
              alt="people working"
              priority
            />
          </div>
          <div className={styles.intro_text}>
            <h2>
              Accesabilidad
              <br /> para todos
            </h2>
            <p>
              En <strong>Inclusive</strong>, nuestra misión es hacer que la
              accesibilidad sea más accesible. Con nuestra aplicación, puedes
              encontrar los lugares más accesibles para ti con un solo clic.
              Bienvenidos a <strong>Inclusive</strong>, donde la accesibilidad
              está al alcance de todos.
            </p>

            <button>
              <Link href="/login">Conéctate</Link>
            </button>
          </div>
        </section>

        <section className={styles.explore}>
          <Image
            src={Img3}
            width={360}
            height={278}
            alt="person in a wheelchair in a gym"
          />
          <div className={styles.explore_text}>
            <h2>
              Explora por
              <br /> <strong>categorías</strong>
            </h2>
            <Link href="/">
              <RightArrowLogo />
            </Link>
          </div>
        </section>

        <section className={styles.topten}>
          <h2>Descubre los lugares mejor valorados</h2>
          <h3>TOP 10 lugares accesibles cerca de ti</h3>
          <div className={styles.topten_cardcontainer}>
            <TopTenCardList />
          </div>
        </section>

        <section className={styles.contribute}>
          <div className={styles.contribute_img}>
            <Image src={Img4} width={312} height={200} alt="hands up" />
          </div>
          <div className={styles.contribute_text}>
            <h2>
              Agrega nuevos
              <br /> lugares y colabora
              <br /> con la comunidad
            </h2>
            <p>
              En <strong>Inclusive</strong>, tú puedes ayudar a hacer que el
              mundo sea más accesible para todos. Agrega nuevos lugares y
              colabora con la comunidad compartiendo tus evaluaciones y
              comentarios. Juntos podemos hacer la diferencia.
            </p>

            <button>
              <Link href="/register-service">Contribuir</Link>
            </button>
          </div>
        </section>

        <section className={styles.faq}>
          <h2>
            Preguntas
            <br /> frecuentes
          </h2>
          <p>
            Encuentra respuestas a tus preguntas sobre{" "}
            <strong>Inclusive</strong>. Aprende cómo agregar nuevos lugares,
            evaluar su accesibilidad y colaborar con la comunidad.
          </p>
          <button>
            <Link href="/faq">Explorar</Link>
          </button>
        </section>
      </div>
    </div>
  );
}

export default Landing;
