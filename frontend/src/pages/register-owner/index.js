import { useEffect, useState } from 'react';

export default function RegisterOwner() {

    const [dias, setDias] = useState([]);
    const [meses, setMeses] = useState([]);
    const [anios, setAnios] = useState([]);

    useEffect(() => {
        function getDiasDelMes(mes, anio) {
          const diasEnElMes = new Date(anio, mes, 0).getDate();
          return Array.from({ length: diasEnElMes }, (_, i) => i + 1);
        }
      
        function getNombresDeMeses() {
          return [
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre",
          ];
        }
      
        function getAnios() {
          const anioActual = new Date().getFullYear();
          return Array.from({ length: anioActual - 1900 + 1 }, (_, i) => i + 1900);
        }
      
        setMeses(getNombresDeMeses());
        setAnios(getAnios());
      
        // obtener días del mes actual
        const fechaActual = new Date();
        setDias(getDiasDelMes(fechaActual.getMonth() + 1, fechaActual.getFullYear()));
      
      }, []);

    return (
        <>

            <div className="contenedorPadre__ow">

                <div className="hijoOwner">

                    <div className="hijoOwner__title">

                        <h1 className="titleRegister">REGISTRA TU LOCAL</h1>
                        <box-icon type='solid' name='x-circle' color='white' size='sm'></box-icon>

                    </div>

                </div>

                <div className="containerTexto">

                    <h2 className="containerTexto__title">Sumá tu comercio a Inclusive (solo personas físicas)</h2>

                </div>

                <div className="line"></div>

                <div className="contenedorHorarios__ow">

                    <div className="contenedorIn__ow">

                        <h2 className='contenedorIn__ow-titulo'>Datos de establecimiento</h2>

                        <input type="text" placeholder="Nombre del establecimiento" className='contenedorIn__ow-nombre' />

                        <input type="text" placeholder="Dirección" className='contenedorIn__ow-direc' />

                        <div className="contDni__genero">

                            <input type="text" placeholder="DNI" className='input__dni' maxLength="8" />

                            <select name="genero" id="genero" className="selectGenero">

                                <option value="masculino">Masculino</option>
                                <option value="femenino">Femenino</option>
                                <option value="todos">Otro</option>

                            </select>

                        </div>

                        <div className='markContainer'>
                            <input type="text" placeholder="Número de trámite" className='inputTramite' />
                            <span className='icon bx bx-question-mark'></span>
                        </div>


                        <h2 className='tituloNacimiento'>Fecha de Nacimiento</h2>

                        <div className="containerSelect__Fecha">

                            <div className='hijoSelect__Fecha'>

                                <div className='selectMes__anio'>

                                    <select name="fecha" id="fecha" className="selectFecha">

                                        {dias.map((dia) => (

                                            <option key={dia} value={dia}>

                                                {dia}

                                            </option>

                                        ))}

                                    </select>

                                    <select name="mes" id="mes" className="selectMes">

                                        {meses.map((mes) => (

                                            <option key={mes} value={mes}>

                                                {mes}

                                            </option>

                                        ))}

                                    </select>

                                    <select name="anio" id="anio" className="selectAnio">

                                        {anios.map((anio) => (

                                            <option key={anio} value={anio}>

                                                {anio}

                                            </option>

                                        ))}

                                    </select>

                                </div>

                                <div className="containerInputTelefono">

                                    <input type="text" className="inputCod" placeholder="Cod." />
                                    <input type="text" className="inputTelefono" placeholder="Teléfono" />

                                </div>

                                <div className='containerEstado-nacion'>

                                    <select name="nacionalidad" id="nacionalidad" className="selectNacionalidad">

                                        <option value="argentina">Argentina</option>
                                        <option value="uruguay">Uruguay</option>
                                        <option value="paraguay">Paraguay</option>

                                    </select>

                                    <select name="civil" id="civil" className="selectCivil">

                                        <option value="soltero">Soltero</option>
                                        <option value="casado">Casado</option>
                                        <option value="divorciado">Divorciado</option>
                                        <option value="viudo">Viudo</option>
                                        <option value="separado">Separado</option>
                                        <option value="union">Unión libre</option>

                                    </select>


                                </div>

                            </div>


                        </div>


                    </div>


                    <div className='containerRadios'>

                        <h2 className='tituloRadio'>¿Sos una persona políticamente expuesta?</h2>

                        <div className='hijoRadio'>

                            <label for="radio1" className='labelRadio'>Si</label>
                            <input type="radio" name="politica" id="politica" value="Si" className='styleSi' />

                            <label for="radio2" className='labelRadio'>No</label>
                            <input type="radio" name="politica" id="politica" value="No" className='styleNo' />

                        </div>

                    </div>

                    <div className="buttonOwner">

                        <button className="botonContinuar">Continuar</button>

                    </div>




                </div>

            </div>


        </>
    );
}

