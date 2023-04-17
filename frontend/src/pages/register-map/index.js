import ServiceCard from "@/components/serviceCard/serviceCard";

export default function RegisterMap() {
    return (
        <>
        
            <div className="contenedorRegister__map">

                <div className="contenedor__preview">

                    <div className="hijo__preview">

                        <h1 className="tituloRegistrar__prev">Vista Previa</h1>
                        <box-icon type='solid' name='x-circle' color='white' size='sm'></box-icon>

                    </div>

                </div>

                <div className="containerMap__view">

                    <div className="hijoMap__view">

                        <ServiceCard fullCard={true} position={[-34.6154303,-58.5981112]} name='Buenos Aires' address='Buenos Aires' hours='10:00' features={['rampa','ascensor','angulo de rampa']} showRating={false} imageSrc={'https://st1.uvnimg.com/dims4/default/0916a6c/2147483647/thumbnail/1024x576%3E/quality/75/?url=https%3A%2F%2Fuvn-brightspot.s3.amazonaws.com%2Fassets%2Fvixes%2F9%2F9-tipos-de-personas-con-los-que-te-sentaras-a-comer-eres-uno-de-ellos3_0.jpg'}/>

                    </div>

                </div>

                <div className="containerButtons">

                    <div className="buttonsFlex">

                        <div className="hijoButtons">

                            <button className="button__editar">Editar</button>
                            <button className="button__continuar">Continuar</button>

                        </div>

                    </div>

                </div>

            </div>

        </>
    );
}

