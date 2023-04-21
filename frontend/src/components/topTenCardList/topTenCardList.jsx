import styles from "../../scss/views/Landing/TopTenCardList.module.scss";

import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import Image from "next/image";

function TopTenCardList() {
  const { data, isLoading, error } = useQuery({
    queryKey: ["topten"],
    queryFn: async () => {
      const response = await axios
        .get("https://inclusive-001-site1.atempurl.com/api/establishment")
        .then((res) => res);

      return response.data;
    },
  });

  if (error) {
    return <h1>Ha ocurrido un error: {error.message}</h1>;
  }

  if (isLoading) {
    return (
      <div className={styles.topten_cardlist}>
        {[...Array(10)].map((e, idx) => {
          return (
            <div className={styles.topten_card} key={idx}>
              <div className={styles.topten_card_label}>Categoria</div>
            </div>
          );
        })}
      </div>
    );
  }

  return (
    <div className={styles.topten_cardlist}>
      {data?.map((e) => {
        return (
          <div className={styles.topten_card} key={e.id}>
            <Image src={e.image} width={140} height={140} alt="photo" />
            <div className={styles.topten_card_label}>{e.name}</div>
          </div>
        );
      })}
    </div>
  );
}

export default TopTenCardList;
