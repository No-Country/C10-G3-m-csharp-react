import MenuNavbar from "@/components/MenuNavbar/MenuNavbar";
import Header from "../../components/Header/Header";
import React, { useState } from "react";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";

function Frequent() {
  const [acordion, setAcordion] = useState(false);

  const getAcordion = () => {
    setAcordion(!acordion);
  };

  return (
    <div className="Container">
      <MenuNavbar />
      <div className="Answers">
        <section>
          <h1 className="Answersh1">Preguntas Frecuentes</h1>
        </section>
        <section className="CloseAnswer">
          <p className="SvgClose">
            <svg
              width="20"
              height="21"
              viewBox="0 0 20 21"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                d="M15.0156 14.1094L11.4062 10.5L15.0156 6.89062L13.6094 5.48438L10 9.09375L6.39062 5.48438L4.98438 6.89062L8.59375 10.5L4.98438 14.1094L6.39062 15.5156L10 11.9062L13.6094 15.5156L15.0156 14.1094ZM2.92188 3.46875C4.89062 1.5 7.25 0.515625 10 0.515625C12.75 0.515625 15.0938 1.5 17.0312 3.46875C19 5.40625 19.9844 7.75 19.9844 10.5C19.9844 13.25 19 15.6094 17.0312 17.5781C15.0938 19.5156 12.75 20.4844 10 20.4844C7.25 20.4844 4.89062 19.5156 2.92188 17.5781C0.984375 15.6094 0.015625 13.25 0.015625 10.5C0.015625 7.75 0.984375 5.40625 2.92188 3.46875Z"
                fill="white"
              />
            </svg>
          </p>
        </section>
      </div>

      <div>
        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography>¿Quiénes pueden utilizar esta aplicacion?</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Esta aplicación está diseñada para personas con discapacidad
              motriz y sus cuidadores, así como para cualquier persona
              interesada en conocer la accesibilidad de los comercios en su
              comunidad.
            </Typography>
          </AccordionDetails>
        </Accordion>
        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography>
              ¿Cómo se los comercios en términos de accesibilidad?
            </Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Los usuarios pueden calificar los comercios utilizando una escala
              de 1 a 5 estrellas en función de su accesibilidad.
            </Typography>
          </AccordionDetails>
        </Accordion>

        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography>
              ¿Cómo puedo encontrar comercios cercanos a mi ubicación actual?
            </Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Puedes utilizar la función de geolocalización en la página
              principal para buscar comercios cercanos a tu ubicación actual.
            </Typography>
          </AccordionDetails>
        </Accordion>
        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography>
              ¿Cómo puedo buscar un comercio en particular?
            </Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Puedes buscar comercios en la sección de &quot;lugares
              destacados&quot; o utilizar la función de búsqueda en la parte
              superior de la pantalla para buscar por nombre, dirección o tipo
              de comercio.
            </Typography>
          </AccordionDetails>
        </Accordion>

        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography>¿Cómo puedo contribuir a la plataforma?</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Puedes contribuir compartiendo tus experiencias y comentarios
              sobre la accesibilidad de los comercios en los que has estado.
              También puedes subir fotos y videos para ayudar a otros usuarios a
              comprender mejor la accesibilidad del lugar.
            </Typography>
          </AccordionDetails>
        </Accordion>
        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography>
              ¿Qué debo hacer si encuentro información incorrecta en un
              comercio?
            </Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Puedes informar sobre información incorrecta o desactualizada
              utilizando la función de reporte que se encuentra en la página de
              cada comercio. De esta manera, el equipo de moderación podrá
              revisar y corregir la información.
            </Typography>
          </AccordionDetails>
        </Accordion>
        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography>
              ¿Cómo puedo registrar mi propio local en la aplicación?
            </Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              En la sección &quot;registra tu local&quot;, podrás proporcionar
              información detallada sobre la accesibilidad de tu local. Una vez
              que hayas completado el registro, el equipo de moderación revisará
              la información y publicará el perfil de tu local en la plataforma.
            </Typography>
          </AccordionDetails>
        </Accordion>

        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel2a-content"
            id="panel2a-header"
          >
            <Typography>¿Cómo se financia la plataforma?</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              La plataforma se financia a través de donaciones, patrocinios y
              publicidad de empresas comprometidas con la accesibilidad y la
              inclusión de personas con discapacidad motriz.
            </Typography>
          </AccordionDetails>
        </Accordion>

        <Accordion>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel2a-content"
            id="panel2a-header"
          >
            <Typography>
              Cómo puedo contactar al equipo de soporte si tengo problemas con
              la aplicación?
            </Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Puedes enviar un correo electrónico al equipo de soporte
              utilizando la dirección de correo electrónico que se encuentra en
              la sección de &quot;datos del usuario&quot;. El equipo de soporte
              responderá lo antes posible para ayudarte con cualquier problema
              que puedas tener.
            </Typography>
          </AccordionDetails>
        </Accordion>
      </div>
    </div>
  );
}

export default Frequent;
