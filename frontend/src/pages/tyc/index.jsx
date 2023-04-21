import styles from "../../scss/views/Tyc/Tyc.module.scss";

function Tyc() {
  return (
    <article className={styles.article}>
      <h1>Términos y condiciones:</h1>

      <h2>Uso del sitio web</h2>
      <p>
        El uso de este sitio web está sujeto a los siguientes términos y
        condiciones. Al acceder y utilizar este sitio web, aceptas estos
        términos y condiciones en su totalidad. Si no estás de acuerdo con estos
        términos y condiciones, no utilices este sitio web.
      </p>

      <h2>Propiedad intelectual</h2>
      <p>
        Los contenidos de este sitio web, incluyendo pero no limitándose a
        textos, imágenes, gráficos, logotipos, marcas comerciales, nombres de
        dominio, nombres de productos y servicios, son propiedad exclusiva de la
        empresa o sus licenciantes y están protegidos por las leyes de propiedad
        intelectual.
      </p>

      <h2>Uso permitido</h2>
      <p>Este sitio web es únicamente para fines informativos y de entretenimiento. No se permite el uso comercial de este sitio web sin el consentimiento expreso y por escrito de la empresa.</p>

      <h2>Contenido del usuario</h2>
      <p>Este sitio web permite a los usuarios publicar contenido, como comentarios y reseñas. Al publicar contenido en este sitio web, el usuario garantiza que tiene el derecho de hacerlo y que el contenido no infringe los derechos de terceros ni viola las leyes aplicables.</p>

      <h2>Limitación de responsabilidad</h2>
      <p>La empresa no se hace responsable de ningún daño directo, indirecto, incidental, especial, consecuente o punitivo que resulte del uso o la imposibilidad de uso de este sitio web.</p>
    </article>
  );
}

export default Tyc;
