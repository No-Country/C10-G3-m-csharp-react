import Image from "next/image";

export default function index() {
    return (
        <>
        
            <div className="containerCheck">

                <div className="hijoCheck">

                    <div className="hijoCheck__ti">

                        <h1 className="tituloRegistrar__check">Registra tu local</h1>
                        <box-icon type='solid' name='x-circle' color='white' size='sm'></box-icon>

                    </div>

                </div>

                <div className='hijoTexto__check'>

                    <h2 className="textoCheck">Tus datos están siendo validados.Dentro de las próximas 48 hs te enviaremos un correo electrónico para informarte el estado de tu solicitud</h2>

                </div>

                <div className="containerImage">

                    <Image src="/img/register-check/check.png" alt="Foto del establecimiento" width={180} height={180}/>

                </div>

                <div className="containerGracias">


                    <h2 className="gracias">Muchas gracias por querer formar parte de <span className="inclusiveColor">Inclusive</span></h2>


                </div>


                <div className="containerButton__inicio">

                    <button className="buttonInicio">Volver al inicio</button>

                </div>


            </div>


        </>
    );
}
