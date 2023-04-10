import AddressLogo from "../addressLogo/addressLogo";
import CalendarLogo from "../calendarLogo/calendarLogo";
import WheelChairLogo from "../wheelChairLogo/wheelChairLogo";
import styles from "../../scss/views/Categories/PlaceCard.module.scss";
import { useState } from "react";
import RatingStars from "../ratingStars/ratingStars";
import FinalRating from "../finalRating/finalRating";
import CheckLogo from "../checkLogo/checkLogo";
import MapCard from "../map/CardMap";
import { CircularProgress } from "@mui/material";
import Image from "next/image";

function PlaceCard() {
  const [showMore, setShowMore] = useState(false);

  const handleClick = () => {
    setShowMore(!showMore);
  };

  if (showMore) {
    return (
      <div className={styles.showMoreCard}>
        <div className={styles.showMore__header}>
          <div className={styles.showMore__img}>
            {/* <Image alt={`place photo`} src={``} width={140} height={80} /> */}
          </div>
          <div className={styles.showMore__map}>
            <div className={styles.showMore__spinnerContainer}>
              <CircularProgress />
            </div>
            <MapCard center={[-34.64933554688625, -58.625932984654476]} />
          </div>
        </div>
        <div className={styles.showMore__text}>
          <h3>LOS PLATITOS</h3>
          <div className={styles.showMore__address}>
            <div>
              <AddressLogo />
            </div>
            <p>Av. Rafael Obligado 1750</p>
          </div>
          <div className={styles.showMore__time}>
            <div>
              <CalendarLogo />
            </div>
            <p>Abierto. 11:30am - 11:00pm</p>
          </div>

          <div className={styles.showMore__mobilityTag}>
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

          <div className={styles.showMore__rating}>
            <p>VALÓRANOS</p>
            {[...Array(5)].map((e, idx) => {
              return (
                <button
                  onClick={() => {
                    console.log(idx + 1);
                  }}
                  key={idx}
                >
                  <RatingStars />
                </button>
              );
            })}
            <FinalRating rating={3} />
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className={styles.card}>
      <div className={styles.img}></div>
      <div className={styles.text}>
        <h3>Corte Comedor</h3>
        <button onClick={handleClick}>Ver datos</button>
      </div>
    </div>
  );
}

export default PlaceCard;
