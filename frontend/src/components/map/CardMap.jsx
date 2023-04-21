import dynamic from "next/dynamic";

const MyMap = dynamic(() => import("../../components/map/map"), {
  ssr: false,
});

function MapCard({center}) {
  return <MyMap center={center} />;
}

export default MapCard;
