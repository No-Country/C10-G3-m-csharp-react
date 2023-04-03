import { MapContainer, TileLayer, Marker } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import styles from "../../scss/views/Categories/MapCard.module.scss"

function Map() {
  const center = [-34.64933554688625, -58.625932984654476];

  return (
    <div>
      <MapContainer
        center={center}
        zoom={14}
        className={styles.mapContainer}
      >
        <TileLayer
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        <Marker
          position={center}
        ></Marker>
      </MapContainer>
    </div>
  );
}

export default Map;
