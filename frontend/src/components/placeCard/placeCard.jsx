import AddressLogo from "../addressLogo/addressLogo";
import CalendarLogo from "../calendarLogo/calendarLogo";
import WheelChairLogo from "../wheelChairLogo/wheelChairLogo";
import styles from "../../scss/views/Categories/PlaceCard.module.scss";
import { useState } from "react";
import RatingStars from "../ratingStars/ratingStars";
import FinalRating from "../finalRating/finalRating";

function PlaceCard() {
  const [showMore, setShowMore] = useState(false);

  const handleClick = () => {
    setShowMore(!showMore);
  };

  if (showMore) {
    return (
      <div className={styles.showMoreCard}>
        <div className={styles.showMore__header}>
          <div className={styles.showMore__img}></div>
          <div className={styles.showMore__img}></div>
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
            <WheelChairLogo />
            <p>Apto - Movilidad Reducida</p>
          </div>
          <div className={styles.showMore__rating}>
            <p>VALÓRANOS</p>
            { [...Array(5)].map((e, idx) => {
              return (
                <RatingStars key={idx}/>
              )
            })}
            <FinalRating rating={3}/>
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
