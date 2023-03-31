import styles from "../../scss/views/Home/NearYouCard.module.scss";
import AddressLogo from "../addressLogo/addressLogo";
import CalendarLogo from "../calendarLogo/calendarLogo";
import WheelChairLogo from "../wheelChairLogo/wheelChairLogo";
import CheckLogo from "../checkLogo/checkLogo";

function NearYouCard() {
  return (
    <div className={styles.featuredCard}>
      <div className={styles.header}>
        <h2>CERCA DE TU UBICACIÓN</h2>
        <div className={styles.img}></div>
      </div>
      <div className={styles.text}>
        <h3>PARQUE SAN FRANCISCO</h3>
        <div className={styles.address}>
          <div>
            <AddressLogo />
          </div>
          <p>San Francisco 2120, B1609 Boulogne</p>
        </div>
        <div className={styles.time}>
          <div>
            <CalendarLogo />
          </div>
          <p>Abierto. 11:30am - 11:00pm</p>
        </div>

        <div className={styles.mobilityTag}>
          <div className={styles.mobilityTag__title}>
            <WheelChairLogo />
            <p>Movilidad Reducida</p>
          </div>

          <ul>
            <li>
              <CheckLogo /> <p>Pasillos amplios</p>
            </li>
            <li>
              <CheckLogo />
              <p>Baños acondicionados</p>
            </li>
            <li>
              <CheckLogo />
              <p>Antideslizante y barras de apoyo</p>
            </li>
          </ul>
        </div>

      </div>
    </div>
  );
}

export default NearYouCard;