import dynamic from "next/dynamic";

const MyMap = dynamic(() => import("../../components/map/map"), {
  ssr: false,
});

function MapCard() {
  return <MyMap />;
}

export default MapCard;
