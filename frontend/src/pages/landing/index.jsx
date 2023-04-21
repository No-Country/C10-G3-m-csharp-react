import Link from "next/link";
import styles from "../../scss/views/Landing/Landing.module.scss";
import Image from "next/image";
import InclusiveLogo from "@/components/inclusiveLogo/inclusiveLogo";
import Instagram from "../../components/Instagram/Instagram"
import Twiter from "../../components/Twiter/Twiter"
import Facebook from "../../components/Facebook/Facebook"
import Footer from "../../components/Footer/Footer"
import Img1 from "../../../public/img/landing/landing-img-1.png";
import Img2 from "../../../public/img/landing/landing-img-2.png";
import Img3 from "../../../public/img/landing/landing-img-3.png";
import Img4 from "../../../public/img/landing/landing-img-4.png";
import img5 from "../../../public/img/landing/women.png"
import img6 from "../../../public/img/landing/women2.png"
import img7 from "../../../public/img/landing/women3.png"
import SearchLogo from "@/components/searchLogo/searchLogo";
import RightArrowLogo from "@/components/rightArrowLogo/rightArrowLogo";
import TopTenCardList from "@/components/topTenCardList/topTenCardList";
import { useRouter } from "next/router";

function Landing() {
  const router = useRouter();
  
  return (
    <div className={styles.Container}>
      <header className={styles.header}>
        <div className={styles.logoContainer}>
          <InclusiveLogo width={121} height={146} />
        </div>
       
        <nav className={styles.navbar}>
          <ul>
            <li>
              <Link href="/">Categorias de lugares</Link>
            </li>
            <li>
              <Link href="/somos">Quienes somos</Link>
            </li>
            <li>
              <Link href="/contact">Contacto</Link>
            </li>
            <li>
              <Link href="/frequent">Preguntas Frecuentes</Link>
            </li>
          </ul>
        </nav>

        <div className={styles.auth}>
          <Link href="/login">
            Login/
            <br />
            Registro
          </Link>
        </div>
      </header>

      <div>
        <section className={styles.welcome}>  
          <Image
            className={styles.images}
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
            </section>
          </div>
          <div className={styles.tituloGeneral}>
            <h1 className={styles.title}>Bienvenidos a INCLUSIVE</h1>

          </div>

        <section className={styles.intro}>
          
          <div className={styles.intro_text}>
            <h2>
              Accesabilidad
              <br /> para todos
            </h2>
            <p className={styles.Parrafo}>
              En <strong>Inclusive</strong>, nuestra misión es hacer que la
              accesibilidad sea más accesible. Con nuestra aplicación, puedes
              encontrar los lugares más accesibles para ti con un solo clic.
              Bienvenidos a <strong>Inclusive</strong>, donde la accesibilidad
              está al alcance de todos.
            </p>

            <button className={styles.buttonLogin}>
              <Link href="/login">Conéctate</Link>
            </button>
            
          </div>
          <div className={styles.intro_img}>
            <Image
             className={styles.images2}
              src={Img2}
              width={312}
              height={200}
              alt="people working"
              priority
            />

          </div>
        </section>

        <section className={styles.explore}>
          <Image
          className={styles.images0}
            src={Img3}
            width={360}
            height={278}
            alt="person in a wheelchair in a gym"
          />
            <Image
            className={styles.imagesNew}
            src={img5}
            width={312}
            height={312}
            />
             <Image
            className={styles.imagesNew2}
            src={img6}
            width={312}
            height={312}
            />
             <Image
            className={styles.imagesNew3}
            src={img7}
            width={312}
            height={312}
            />
          <div className={styles.explore_text}>
            <h2 className={styles.texto}>
              Explora por
              <br /> <strong>categorías</strong>
            </h2>
            <Link href="/" className={styles.link}>
              <RightArrowLogo />
            </Link>
          </div>
        </section>

        <section className={styles.topten}>
          <h2>Descubre los lugares mejor valorados</h2>
          <h3>TOP 10 lugares accesibles cerca de ti</h3>
          <div className={styles.topten_cardcontainer}>
            <TopTenCardList/>
          </div>
        </section>

        <section className={styles.contribute}>
        
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

            <button className={styles.buttonService}>
              <Link href="/register-service">Contribuir</Link>
            </button>
          </div>
          <div className={styles.contribute_img}>
            <Image className={styles.image3} src={Img4} width={312} height={200} alt="hands up" />
          </div>
        </section>

        <section className={styles.faq}>
          <h2 className={styles.Answer}>
            <span> Preguntas </span> 
            <br /> <span> frecuentes </span>
          </h2>
          <p className={styles.ParrafoAnswer}>
            Encuentra respuestas a tus preguntas sobre{" "}
            <strong>Inclusive</strong>. Aprende cómo agregar nuevos lugares,
            evaluar su accesibilidad y colaborar con la comunidad.
          </p>
          <button>
            <Link href="/frequent">Explorar</Link>
          </button>
        </section>
     
    <div>
      <Footer/>
    </div>
       

       
     
    </div>
  );
  
}

export default Landing;
