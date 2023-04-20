import { useEffect, useState } from 'react';

export default function RegisterOwner({ handleNextStep, establishment, setEstablishment }) {

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

    const handleContinuar = () => {

        setEstablishment(establishment => ({

            ...establishment

        }));

        handleNextStep();

        console.log(establishment);

    }

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

                        <input type="text" placeholder="Nombres" className='contenedorIn__ow-nombre' value={establishment.owner.name || ''} onChange={(e) =>
                            setEstablishment((establishment) => ({
                                ...establishment,
                                owner: {
                                    ...establishment.owner,
                                    name: e.target.value,
                                },
                            }))
                        } />

                        <input type="text" placeholder="Apellidos" className='contenedorIn__ow-nombre' value={establishment.owner.surNames || ''} onChange={(e) =>
                            setEstablishment((establishment) => ({
                                ...establishment,
                                owner: {
                                    ...establishment.owner,
                                    surNames: e.target.value,
                                },
                            }))
                        } />

                        <div className="contDni__genero">

                            <input type="text" placeholder="DNI" className='input__dni' maxLength="8" value={establishment.owner.dni || ''} onChange={(e) =>
                                setEstablishment((establishment) => ({
                                    ...establishment,
                                    owner: {
                                        ...establishment.owner,
                                        dni: e.target.value,
                                    },
                                }))
                            } />

                            <select name="genero" id="genero" className="selectGenero" value={establishment.owner.gender || ''} onChange={(e) =>
                                setEstablishment((establishment) => ({
                                    ...establishment,
                                    owner: {
                                        ...establishment.owner,
                                        gender: e.target.value,
                                    },
                                }))
                            }>

                                <option value="masculino">Masculino</option>
                                <option value="femenino">Femenino</option>
                                <option value="todos">Otro</option>

                            </select>

                        </div>

                        <div className='markContainer'>
                            <input type="text" placeholder="Número de trámite" className='inputTramite' value={establishment.owner.tramitNumber || ''} onChange={(e) =>
                                setEstablishment((establishment) => ({
                                    ...establishment,
                                    owner: {
                                        ...establishment.owner,
                                        tramitNumber: e.target.value,
                                    },
                                }))
                            } />
                            <span className='icon bx bx-question-mark'></span>
                        </div>


                        <h2 className='tituloNacimiento'>Fecha de Nacimiento</h2>

                        <div className="containerSelect__Fecha">

                            <div className='hijoSelect__Fecha'>

                                <div className='selectMes__anio' value={establishment.owner.birthDate || ''} onChange={(e) =>
                                    setEstablishment((establishment) => ({
                                        ...establishment,
                                        owner: {
                                            ...establishment.owner,
                                            birthDate: e.target.value,
                                        },
                                    }))
                                }>

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

                                    <input type="text" className="inputCod" placeholder="Cod." value={establishment.owner.phoneCode || ''} onChange={(e) =>
                                        setEstablishment((establishment) => ({
                                            ...establishment,
                                            owner: {
                                                ...establishment.owner,
                                                phoneCode: e.target.value,
                                            },
                                        }))
                                    } />
                                    <input type="text" className="inputTelefono" placeholder="Teléfono" value={establishment.owner.phoneNumber || ''} onChange={(e) =>
                                        setEstablishment((establishment) => ({
                                            ...establishment,
                                            owner: {
                                                ...establishment.owner,
                                                phoneNumber: e.target.value,
                                            },
                                        }))
                                    } />

                                </div>

                                <div className='containerEstado-nacion'>

                                    <select name="nacionalidad" id="nacionalidad" className="selectNacionalidad" value={establishment.owner.nationality || ''} onChange={(e) =>
                                        setEstablishment((establishment) => ({
                                            ...establishment,
                                            owner: {
                                                ...establishment.owner,
                                                nationality: e.target.value,
                                            },
                                        }))
                                    }>

                                        <option value="argentina">Argentina</option>
                                        <option value="uruguay">Bolivia</option>
                                        <option value="paraguay">Brasil</option>
                                        <option value="paraguay">Chile</option>
                                        <option value="paraguay">Colombia</option>
                                        <option value="paraguay">Ecuador</option>
                                        <option value="paraguay">Paraguay</option>
                                        <option value="paraguay">Perú</option>
                                        <option value="paraguay">Uruguay</option>
                                        <option value="paraguay">Venezuela</option>

                                    </select>

                                    <select name="civil" id="civil" className="selectCivil" value={establishment.owner.maritalStatus || ''} onChange={(e) =>
                                        setEstablishment((establishment) => ({
                                            ...establishment,
                                            owner: {
                                                ...establishment.owner,
                                                maritalStatus: e.target.value,
                                            },
                                        }))
                                    }>

                                        <option value="soltero">Casado</option>
                                        <option value="casado">Soltero</option>
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

                        <div className='hijoRadio' value={establishment.owner.pep || ''} onChange={(e) =>
                            setEstablishment((establishment) => ({
                                ...establishment,
                                owner: {
                                    ...establishment.owner,
                                    pep: e.target.value,
                                },
                            }))
                        }>

                            <label for="radio1" className='labelRadio'>Si</label>
                            <input type="radio" name="politica" id="politica" value="Si" className='styleSi' />

                            <label for="radio2" className='labelRadio'>No</label>
                            <input type="radio" name="politica" id="politica" value="No" className='styleNo' />

                        </div>

                    </div>

                    <div className="buttonOwner">

                        <button type='button' className="botonContinuar" onClick={handleContinuar}>Continuar</button>

                    </div>




                </div>

            </div>


        </>
    );
}

