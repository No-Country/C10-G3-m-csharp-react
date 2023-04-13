import { useState } from "react";

export default function index() {

    const [showTextArea, setShowTextArea] = useState(false);
    const [isAnimating, setIsAnimating] = useState(false);

    const handleShowTextArea = (event) => {

        setIsAnimating(true);

        setTimeout(() => {

            setShowTextArea(event.target.checked);
            setIsAnimating(false);


        }, 300)

    }

    return (
        
        <>
        
            <div className="contenedorCategorias">

                <div className="tituloContainer">

                    <div className="hijoTitulo">

                        <h1 className="tituloRegistra">REGISTRA TU LOCAL</h1>
                        <box-icon type='solid' name='x-circle' color='white' size='sm'></box-icon>

                    </div>

                </div>

                <div className="parrafoCategorias">

                    <p className="parrafoCara">Seleccione las características que
                        su establecimiento posee para <span className="textDis">personas discapacitadas</span></p>

                </div>

                <div className="line"></div>

                <div className="contenedorCheck">

                    <div className="checkContainer">

                        <div className="checkHijo">

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox1" value="first_checkbox" />
                                <label className="labelCheck" for="cbox1">Rampa</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox2" value="first_checkbox" />
                                <label className="labelCheck" for="cbox2">Ángulo de rampa</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox3" value="first_checkbox" />
                                <label className="labelCheck" for="cbox3">Mobiliario</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox4" value="first_checkbox" />
                                <label className="labelCheck" for="cbox4">Personal asistente</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox5" value="first_checkbox" />
                                <label className="labelCheck" for="cbox5">Ancho de pasillo (mínimo 140 cm)</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox6" value="first_checkbox" />
                                <label className="labelCheck" for="cbox6">Ascensor</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox7" value="first_checkbox" />
                                <label className="labelCheck" for="cbox7">Baño accesible</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox8" value="first_checkbox" />
                                <label className="labelCheck" for="cbox8">Altura de mostrador</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox9" value="first_checkbox" />
                                <label className="labelCheck" for="cbox9">Estacionamiento adaptado</label>

                            </div>

                            <div className='typeCheck'>

                                <input type="checkbox" id="cbox10" value="first_checkbox" onClick={handleShowTextArea}/>
                                <label className="labelCheck" for="cbox10" htmlFor="cbox10">Otros (Escribelo)</label>

                            </div>

                            <div className="containerShow">

                                {showTextArea && <textarea style={{ display: showTextArea ? 'block' : 'none', opacity: isAnimating ? 0 : 1 }} className="textArea" placeholder="Escribe aquí..."></textarea>}

                            </div>

                        </div>

                    </div>

                </div>

            </div>


        </>

    );
}