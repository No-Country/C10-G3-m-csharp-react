import { MapContainer, TileLayer, Marker } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import styles from "../../scss/views/Categories/MapCard.module.scss";

import L from "leaflet";

function Map({center}) {

  const position = center;

  const myIcon = L.icon({
    iconUrl: "data:image/svg+xml,%3Csvg width='24px' height='24px' viewBox='-4 0 36 36' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' fill='%23000000'%3E%3Cg id='SVGRepo_bgCarrier' stroke-width='0'%3E%3C/g%3E%3Cg id='SVGRepo_tracerCarrier' stroke-linecap='round' stroke-linejoin='round'%3E%3C/g%3E%3Cg id='SVGRepo_iconCarrier'%3E%3C!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools --%3E%3Ctitle%3Emap-marker%3C/title%3E%3Cdesc%3ECreated with Sketch.%3C/desc%3E%3Cdefs%3E%3C/defs%3E%3Cg id='Vivid.JS' stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'%3E%3Cg id='Vivid-Icons' transform='translate(-125.000000, -643.000000)'%3E%3Cg id='Icons' transform='translate(37.000000, 169.000000)'%3E%3Cg id='map-marker' transform='translate(78.000000, 468.000000)'%3E%3Cg transform='translate(10.000000, 6.000000)'%3E%3Cpath d='M14,0 C21.732,0 28,5.641 28,12.6 C28,23.963 14,36 14,36 C14,36 0,24.064 0,12.6 C0,5.641 6.268,0 14,0 Z' id='Shape' fill='%238BB9FF'%3E%3C/path%3E%3Ccircle id='Oval' fill='%23F1F7FF' fill-rule='nonzero' cx='14' cy='14' r='7'%3E%3C/circle%3E%3C/g%3E%3C/g%3E%3C/g%3E%3C/g%3E%3C/g%3E%3C/g%3E%3C/svg%3E"
})

  return (
    <div>
      <MapContainer center={position} zoom={14} className={styles.mapContainer}>
        <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
        <Marker position={position} icon={myIcon}></Marker>
      </MapContainer>
    </div>
  );
}

export default Map;
