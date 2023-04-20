import Image from "next/image";
import img1 from "@/../../public/img/somos/appstorebanner.png";
import img2 from "@/../../public/img/somos/headerbanner.jpg";
import img3 from "@/../../public/img/somos/oldlady.png";
import img4 from "@/../../public/img/somos/oldman.png";
import img5 from "@/../../public/img/somos/phone1.png";
import img6 from "@/../../public/img/somos/phone2.png";
import img7 from "@/../../public/img/somos/playstorebanner.png";

import styles from "../../scss/views/Somos/Somos.module.scss";

function Somos() {
  return (
    <>
      <div className={styles.header}>
        <Image alt="header banner" sizes="100vw" src={img2} fill />
        <div></div>
        <h1>Somos INCLUSIVE</h1>
      </div>

      <div className={styles.first}>
        <div className={styles.first_text}>
          <p>
            ¡Bienvenidos a <strong>INCLUSIVE!</strong> Somos un equipo
            comprometido con la inclusión y la accesibilidad de las personas con
            discapacidades motrices. Nuestro objetivo es facilitar su acceso a
            los comercios y lugares públicos, ofreciendo información clara y
            detallada sobre la accesibilidad de los mismos.
          </p>
          <p>
            Somos conscientes de los obstáculos que las personas con
            discapacidad motriz enfrentan a diario debido a la falta de
            infraestructura y diseño urbano inclusivo, lo cual limita su
            movilidad y autonomía. Es por eso que nos hemos propuesto contribuir
            a solucionar este problema.
          </p>
          <p>
            Nuestra plataforma también busca que los usuarios puedan anticipar y
            prever los problemas de movilidad que puedan surgir de manera
            imprevista, brindando soluciones y recursos para mejorar la calidad
            de vida de las personas con discapacidad motriz y sus cuidadores.
          </p>
        </div>
        <Image alt="" width={300} height={40} src={img3} />
      </div>

      <div className={styles.second}>
        <Image alt="old man" width={300} height={40} src={img4} />
        <div className={styles.second_text}>
          <p>
            Te invitamos a participar en nuestra causa colaborando activamente
            en nuestra plataforma, agregando fotos, comentarios, puntuaciones y
            ayudándonos así a hacer visible la problemática, para que se tome
            consciencia de las necesidades reales que viven diariamente las
            personas con discapacidades motrices y, desde la visibilización,
            logremos cambiar la realidad.
          </p>
          <p>
            Estamos comprometidos en nuestra labor y trabajamos con el objetivo
            de lograr una sociedad más inclusiva y accesible para todos.
          </p>
          <p>¡Gracias por visitarnos!</p>
        </div>
      </div>
        <h2 className={styles.subtitle}>Descarga la app</h2>

      <div className={styles.third}>
        <Image alt="phone1" width={250} height={40} src={img5} />
        <div className={styles.third_banner}>
          <Image alt="descargar app store" width={150} height={40} src={img1} />
          <Image alt="descargar play store" width={150} height={40} src={img7} />
        </div>
        <Image alt="phone2" width={250} height={40} src={img6} />
      </div>
    </>
  );
}

export default Somos;
