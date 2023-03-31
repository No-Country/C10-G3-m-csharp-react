import styles from "../../scss/views/Home/FeaturedCard.module.scss";
import AddressLogo from "../addressLogo/addressLogo";
import CalendarLogo from "../calendarLogo/calendarLogo";
import CheckLogo from "../checkLogo/checkLogo";
import WheelChairLogo from "../wheelChairLogo/wheelChairLogo";

function FeaturedCard() {
  return (
    <div className={styles.featuredCard}>
      <div className={styles.header}>
        <h2>DESTACADO</h2>
        <div className={styles.img}></div>
      </div>
      <div className={styles.text}>
        <h3>LOS PLATITOS</h3>
        <div className={styles.address}>
          <div>
            <AddressLogo />
          </div>
          <p>Av. Rafael Obligado 1750</p>
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

export default FeaturedCard;
