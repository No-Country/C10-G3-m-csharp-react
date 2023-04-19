import RegisterServicio from '@/components/registerService/Servicio';
import React, { useState } from 'react';
import RegisterOwner from '../register-owner';
import RegisterMap from '../register-map';
import RegisterCheck from '../register-check';
import Servicio from '@/components/registerService/Servicio';
import RegisterCara from '../register-cara';

export default function RegisterService() {

    const [establishment, setEstablishment] = useState({

        steps: 1,
        id: "",
        name: "",
        address: "",
        latitude: "",
        longitude: "",
        phoneNumber: "",
        openingTime: "",
        closingTime: "",
        webSite: null,
        image: "",
        requestedDate: "",
        requestStatus: 0,
        approvedDate: "",
        approvalUserId: null,
        categoryId: "",
        accessibilitys: []

    });

    const handleNextStep = () => {

        setEstablishment({...establishment, steps: establishment.steps + 1});

    }


    let currentStep;

    if(establishment.steps === 1){

        return <Servicio establishment={establishment} onNextStep={handleNextStep} setEstablishment={setEstablishment}/>

    } else if (establishment.steps === 2) {

        return <RegisterOwner establishment={establishment} onNextStep={handleNextStep} setEstablishment={setEstablishment}/>

    } else if(establishment.steps === 3) {

        return <RegisterCara establishment={establishment} onNextStep={handleNextStep} setEstablishment={setEstablishment}/>

    } else if(establishment.steps === 4) {

        return <RegisterMap establishment={establishment} onNextStep={handleNextStep} setEstablishment={setEstablishment}/>

    } else if(establishment.steps === 5) {

        return <RegisterCheck establishment={establishment} onNextStep={handleNextStep} setEstablishment={setEstablishment}/>

    } else {

        currentStep = <div>Paso desconocido</div>

    }

    return (
        <>

            {currentStep}

        </>
    )
}

