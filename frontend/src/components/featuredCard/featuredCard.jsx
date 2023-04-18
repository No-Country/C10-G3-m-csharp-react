import styles from "../../scss/views/Home/FeaturedCard.module.scss";
import AddressLogo from "../addressLogo/addressLogo";
import CalendarLogo from "../calendarLogo/calendarLogo";
import CheckLogo from "../checkLogo/checkLogo";
import WheelChairLogo from "../wheelChairLogo/wheelChairLogo";

import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import Image from "next/image";

function FeaturedCard() {
  const { data, isLoading, error } = useQuery({
    queryKey: ["featured"],
    queryFn: async () => {
      const response = await axios
        .get(
          "https://inclusive-001-site1.atempurl.com/api/establishment/a9870b9d-f5d5-4281-af4d-08db3edbef24"
        )
        .then((res) => res);
      return response.data;
    },
  });

  if (error) {
    return <h1>Ha ocurrido un error: {error.message}</h1>;
  }

  if (isLoading) {
    return (
      <div className={styles.featuredCard}>
        <div className={styles.header}>
          <h2>DESTACADO</h2>
          <div className={styles.img}></div>
        </div>
        <div className={styles.text}>
          <h3>Cargando...</h3>
          <div className={styles.address}>
            <div>
              <AddressLogo />
            </div>
            <p>Cargando...</p>
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
              {[...Array(3)].map((e) => {
                return (
                  <li key={e?.id}>
                    <CheckLogo /> <p>{e?.name}</p>
                  </li>
                );
              })}
            </ul>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className={styles.featuredCard}>
      <div className={styles.header}>
        <h2>DESTACADO</h2>
        <div className={styles.img}>
          <Image src={data?.image} alt="photo" width={296} height={178}  />
        </div>
      </div>
      <div className={styles.text}>
        <h3>{data?.name}</h3>
        <div className={styles.address}>
          <div>
            <AddressLogo />
          </div>
          <p>{data?.address}</p>
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
          {data?.accessibilitys?.map((e) => {
                return (
                  <li key={e?.id}>
                    <CheckLogo /> <p>{e?.name}</p>
                  </li>
                );
              })}
          </ul>
        </div>
      </div>
    </div>
  );
}

export default FeaturedCard;
