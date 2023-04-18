import React from 'react';

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

    return (
        <>

            <RegisterService/>

        </>
    )
}

