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

function PlaceCard({
  fullCard,
  position,
  imageSrc,
  name,
  address,
  hours,
  features,
  rating,
  showRating,
}) {
  const [showMore, setShowMore] = useState(fullCard);

  const handleClick = () => {
    setShowMore(!showMore);
  };

  if (showMore) {
    return (
      <div className={styles.showMoreCard}>
        <div className={styles.showMore__header}>
          <div className={styles.showMore__img}>
            {imageSrc && (
              <Image
                alt={`place photo`}
                src={imageSrc}
                width={140}
                height={80}
              />
            )}
          </div>
          <div className={styles.showMore__map}>
            <div className={styles.showMore__spinnerContainer}>
              <CircularProgress />
            </div>
            <MapCard center={[position[0], position[1]]} />
          </div>
        </div>
        <div className={styles.showMore__text}>
          <h3>{name}</h3>
          <div className={styles.showMore__address}>
            <div>
              <AddressLogo />
            </div>
            <p>{address}</p>
          </div>
          <div className={styles.showMore__time}>
            <div>
              <CalendarLogo />
            </div>
            <p>Abierto. {hours}</p>
          </div>

          <div className={styles.showMore__mobilityTag}>
            <div className={styles.mobilityTag__title}>
              <WheelChairLogo />
              <p>Movilidad Reducida</p>
            </div>

            <ul>
              {features.map((e, idx) => {
                return (
                  <li key={idx}>
                    <CheckLogo />
                    <p>{e.name}</p>
                  </li>
                );
              })}
            </ul>
          </div>

          {showRating && (
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
              <FinalRating rating={Math.trunc(rating)} />
            </div>
          )}
        </div>
      </div>
    );
  } else {
    return (
      <div className={styles.card}>
        <div className={styles.img}>
          {imageSrc && (
            <Image alt={`place photo`} src={imageSrc} width={140} height={80} />
          )}
        </div>
        <div className={styles.text}>
          <h3>{name}</h3>
          <button onClick={handleClick}>Ver datos</button>
        </div>
      </div>
    );
  }
}

export default PlaceCard;
