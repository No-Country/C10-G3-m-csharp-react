import styles from "../../scss/views/Tyc/Tyc.module.scss";

function Privacy() {
  return (
    <article className={styles.article}>
      <h1>Política de privacidad:</h1>

      <h2>Información recopilada</h2>
      <p>
        Recopilamos información personal de los usuarios, como el nombre, la
        dirección de correo electrónico y la ubicación geográfica, cuando se
        registran en nuestro sitio web. También podemos recopilar información no
        personal, como el tipo de navegador y el sistema operativo utilizado.
      </p>

      <h2>Uso de la información</h2>
      <p>
        Utilizamos la información recopilada para proporcionar y mejorar
        nuestros servicios, personalizar la experiencia del usuario,
        comunicarnos con los usuarios y enviar información promocional y
        publicitaria.
      </p>

      <h2>Divulgación de la información</h2>
      <p>
        Este sitio web es únicamente para fines informativos y de
        entretenimiento. No se permite el uso comercial de este sitio web sin el
        consentimiento expreso y por escrito de la empresa.
      </p>

      <h2>Seguridad de la información</h2>
      <p>
        Tomamos medidas razonables para proteger la información personal de los
        usuarios de accesos no autorizados, la divulgación y el uso indebido.
      </p>

      <h2>Modificaciones a la política de privacidad</h2>
      <p>
        Podemos modificar esta política de privacidad en cualquier momento. La
        versión actualizada se publicará en nuestro sitio web. Al continuar
        utilizando nuestro sitio web después de que se hayan publicado las
        modificaciones a esta política de privacidad, aceptas las
        modificaciones.
      </p>
    </article>
  );
}

export default Privacy;
