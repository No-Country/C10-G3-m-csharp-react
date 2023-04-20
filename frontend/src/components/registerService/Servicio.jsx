import Image from "next/image";
import React, { useState, useEffect } from 'react';

function Servicio({establishment,setEstablishment,onNextStep}) {

    const [hours, setHours] = useState([]);

    const handleFileSelect = () => {

        document.getElementById("archivo").click();

    }

    useEffect(() => {

        const allHours = [];

        for (let i = 1; i <= 12; i++) {

            allHours.push(`${i.toString().padStart(2, '0')}:00 AM`);

        }
        for (let i = 1; i <= 12; i++) {

            allHours.push(`${i.toString().padStart(2, '0')}:00 PM`);

        }

        const sortedHours = [...allHours.slice(0, 12), ...allHours.slice(12).sort()];

        const formattedHours = sortedHours.map(hour => {

            const [h, m] = hour.split(':'); // Separa las horas y los minutos de la cadena de la hora
            return `${h.padStart(2, '0')}:${m.padEnd(2, '0')}`; // Devuelve la hora en el formato deseado HH:mm

        });

        setHours(formattedHours);

        console.log(allHours);

    }, []);

    const handleName = (name) => {

        setEstablishment({ ...establishment, name: name });

    }

    const handleAddress = (address) => {

        setEstablishment({ ...establishment, address: address });

    }

    const handleOpening = (openingTime) => {

        setEstablishment({ ...establishment, openingTime: openingTime });

    }

    const handleClosing = (closingTime) => {

        setEstablishment({ ...establishment, closingTime: closingTime });

    }

    const handleImage = (image) => {

        setEstablishment({ ...establishment, image: image });

    }

    const handleNextClick = () => {

        console.log(establishment);
        onNextStep();

    }


    return (
        <>

            <div className='contenedorPadre__local'>

                <div className="hijoRegistrar">

                    <div className="hijoRegistrar__cont">

                        <h1 className="tituloRegistrar__local">REGISTRA TU LOCAL</h1>
                        <box-icon type='solid' name='x-circle' color='white' size='sm'></box-icon>

                    </div>

                </div>

                <div className='hijoTexto'>

                    <h2 className="hijoTexto-inclusive">Sumá tu comercio a Inclusive (solo personas físicas)</h2>

                </div>

                <div className="line"></div>

                <form>

                    <div className='contenedorDatos__estable'>

                        <div className='contenedorInputs__estable'>

                            <h2 className='contenedorInputs__titulo'>Datos de establecimiento</h2>

                            <input type="text" placeholder="Nombre del establecimiento" className='contenedorInputs__nombre' value={establishment.name} onChange={(e) => handleName(e.target.value)}/>

                            <input type="text" placeholder="Dirección" className='contenedorInputs__direc' name="address" value={establishment.address} onChange={(e) => handleAddress(e.target.value)}/>

                        </div>

                        <div className="contenedorHorarios__padre">

                            <h2 className="contenedorHorarios__titulo">Horario de atención al público</h2>

                            <div className='contenedorDias'>

                                <select name="dias" id="dias" className="selectDias">

                                    <option value="fines">Solo fines de semana</option>
                                    <option value="lunyvie">Lunes a viernes</option>
                                    <option value="todos">Todos los días</option>

                                </select>

                            </div>

                            <div className="contenedorSelects">

                                <div className="hijoSelects">


                                    <select name="openingTime" id="provincia" className="selectStyle" value={establishment.openingTime} onChange={(e) => handleOpening(e.target.value)}>

                                        {hours?.map((hour, index) => (
                                            <option key={index}>
                                                {hour}
                                            </option>
                                        ))}

                                    </select>

                                    <p className="textoA">a</p>

                                    <select name="closingTime" id="provincia" className="selectStyle" value={establishment.closingTime} onChange={(e) => handleClosing(e.target.value)}>

                                        {hours?.map((hour, index) => (
                                            <option key={index}>
                                                {hour}
                                            </option>
                                        ))}

                                    </select>

                                </div>

                            </div>


                        </div>

                        <div className="contenedorFile__button">

                            <div className="contenedorTexto__portada">

                                <h2 className="textoPortada">Foto de Portada (Opcional)</h2>

                            </div>

                            <div className="hijoFile" onClick={handleFileSelect}>


                                <div className="contenedorArchivo">

                                    <label htmlFor="archivo" className="subirArchivo">Subir Archivo</label>
                                    <Image src='/img/register-service/file/file-upload.png' quality={100} height={50} width={60} loading="lazy" objectFit="cover" alt="" />

                                </div>

                                <input type="file" id="archivo" alt='Imagen para subir archivo' placeholder="Subir archivo" accept="image/*" value={establishment.image} onChange={(e) => handleImage(e.target.value)}/>


                            </div>


                            <div className="hijoButton">

                                <button className="botonCont" onClick={handleNextClick}>Continuar</button>

                            </div>

                        </div>

                    </div>

                </form>

            </div>

        </>
    )
}

export default Servicio;