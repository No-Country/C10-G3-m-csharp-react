import { useEffect, useState } from "react";
const API = 'https://inclusive-001-site1.atempurl.com/api/accessibility';


export default function index() {
    
    const [showTextArea, setShowTextArea] = useState(false);
    const [isAnimating, setIsAnimating] = useState(false);
    const [accessibilityData, setAccessibilityData] = useState(null);

    const handleShowTextArea = (event) => {

        setIsAnimating(true);

        setTimeout(() => {

            setShowTextArea(event.target.checked);
            setIsAnimating(false);


        }, 300)

    }

    useEffect(() => {


        async function fetchData() {

            try {

                const response = await fetch(API);
                const data = await response.json();
                setAccessibilityData(data);

            } catch {
                
                console.log('Error');

            }

        }

        fetchData();

    }, [])

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

                            {accessibilityData && accessibilityData.map(item => (
                                <div className='typeCheck' key={item.id}>

                                    <input type="checkbox" id="cbox1" value="first_checkbox" />
                                    <label className="labelCheck" for="cbox1">{item.name}</label>

                                </div>
                            ))}          

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