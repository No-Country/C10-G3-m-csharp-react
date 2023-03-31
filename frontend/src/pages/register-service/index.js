import Image from "next/image";

export default function RegisterService() {

    const handleFileSelect = () => {
        
        document.getElementById("archivo").click();

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

            <div className='contenedorDatos__estable'>

                <div className='contenedorInputs__estable'>

                    <h2 className='contenedorInputs__titulo'>Datos de establecimiento</h2>

                    <input type="text" placeholder="Nombre del establecimiento" className='contenedorInputs__nombre'/>

                    <input type="text" placeholder="Dirección" className='contenedorInputs__direc'/>

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


                            <select name="provincia" id="provincia" className="selectStyle">

                                <option value="00:00">00:00</option>
                                <option value="01:00">01:00</option>
                                <option value="02:00">02:00</option>

                            </select>

                            <p className="textoA">a</p>

                            <select name="provincia" id="provincia" className="selectStyle">

                                <option value="00:00">00:00</option>
                                <option value="00:00">01:00</option>
                                <option value="00:00">02:00</option>

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
                            <Image src='/img/register-service/file/file-upload.png' quality={100} height={50} width={60} loading="lazy" objectFit="cover"/>
                            
                        </div>
                        
                        <input type="file" id="archivo" alt='Imagen para subir archivo' placeholder="Subir archivo" accept="image/*"/>

                    </div>

                    
                    <div className="hijoButton">

                        <button className="botonCont">Continuar</button>

                    </div>

                </div>

            </div>
  
        </div>
  
      </>
    )
  }
  
  