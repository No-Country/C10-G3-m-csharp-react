import MenuNavbar from "@/components/MenuNavbar/MenuNavbar";
import Header from "../../components/Header/Header"
import React, { useState } from "react";
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';






function frequent() {

    const [acordion, setAcordion] = useState(false)

    const getAcordion = () => {
        setAcordion(!acordion)
    }

    return (
        <div className="Container">
            <MenuNavbar />
            <div className="Answers">
                <section>
                    <h1 className="Answersh1">Preguntas Frecuentes</h1>
                </section>
                <section className="CloseAnswer">
                    <p className="SvgClose">
                        <svg width="20" height="21" viewBox="0 0 20 21" fill="none" xmlns="http://www.w3.org/2000/svg">
                            <path d="M15.0156 14.1094L11.4062 10.5L15.0156 6.89062L13.6094 5.48438L10 9.09375L6.39062 5.48438L4.98438 6.89062L8.59375 10.5L4.98438 14.1094L6.39062 15.5156L10 11.9062L13.6094 15.5156L15.0156 14.1094ZM2.92188 3.46875C4.89062 1.5 7.25 0.515625 10 0.515625C12.75 0.515625 15.0938 1.5 17.0312 3.46875C19 5.40625 19.9844 7.75 19.9844 10.5C19.9844 13.25 19 15.6094 17.0312 17.5781C15.0938 19.5156 12.75 20.4844 10 20.4844C7.25 20.4844 4.89062 19.5156 2.92188 17.5781C0.984375 15.6094 0.015625 13.25 0.015625 10.5C0.015625 7.75 0.984375 5.40625 2.92188 3.46875Z" fill="white" />
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
                      <> <input type="text" placeholder="Respuesta" /> </> 
                    </Typography>
                </AccordionDetails>
                
            </Accordion>
            <Accordion>
                <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    aria-controls="panel1a-content"
                    id="panel1a-header"
                >
                    <Typography>¿Cómo puedo buscar un comercio en particular?</Typography>
                </AccordionSummary>
                <AccordionDetails>
                    <Typography>
                    <> <input type="text" placeholder="Respuesta" /> </> 
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
                    <> <input type="text" placeholder="Respuesta" /> </> 
                    </Typography>
                </AccordionDetails>
                
            </Accordion>
            <Accordion>
                <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    aria-controls="panel1a-content"
                    id="panel1a-header"
                >
                    <Typography>¿Qué debo hacer si encuentro información incorrecta en un comercio?</Typography>
                </AccordionSummary>
                <AccordionDetails>
                    <Typography>
                    <> <input type="text" placeholder="Respuesta" /> </> 
                    </Typography>
                </AccordionDetails>
                
            </Accordion>
            <Accordion>
                <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    aria-controls="panel1a-content"
                    id="panel1a-header"
                >
                    <Typography>¿Cómo puedo registrar mi propio local en la aplicación?</Typography>
                </AccordionSummary>
                <AccordionDetails>
                    <Typography>
                    <> <input type="text" placeholder="Respuesta" /> </> 
                    </Typography>
                </AccordionDetails>
                
            </Accordion>
            <Accordion>
                <AccordionSummary
                    expandIcon={<ExpandMoreIcon />}
                    aria-controls="panel2a-content"
                    id="panel2a-header"
                >
                    <Typography>Cómo puedo contactar al equipo de soporte si tengo problemas con la aplicación?</Typography>
                </AccordionSummary>
                <AccordionDetails>
                    <Typography>
                    <> <input type="text" placeholder="Respuesta" /> </> 
                    </Typography>
                </AccordionDetails>
            </Accordion>
            </div> 
        </div>
    )
}


export default frequent;