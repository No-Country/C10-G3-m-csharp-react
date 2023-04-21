import { useRouter } from "next/router";
import { useQuery } from "@tanstack/react-query";
import { CircularProgress } from "@mui/material";
import styles from "../../scss/views/Search/Search.module.scss"
import axios from "axios";
import PlaceCard from "@/components/placeCard/placeCard";
import useHighWidth from "@/utils/useHighWidth";

function Search() {

  const isHighWidth = useHighWidth()

  const router = useRouter();
  const { term } = router.query

  const { data, isLoading, error } = useQuery({
    queryKey: ["search", term],
    queryFn: async () => {
      const response = await axios
        .get(`https://inclusive-001-site1.atempurl.com/api/establishment?SearchColumn=name&SearchTerm=${term}&PageSize=10`)
        .then((res) => res);
      return response.data;
    },
  });

  if (error) {
    return <h1>Ha ocurrido un error: {error.message}</h1>;
  }

  if (isLoading) {
    return (
      <div className={styles.loadingSpinner}>
       <CircularProgress />
      </div>
    );
  }

  if (data.length === 0) {
    return (
      <div className={styles.loadingSpinner}>
       <h1>Esta búsqueda no ha generado resultados.</h1>
      </div>
    );
  }

  return (
    <ul className={styles.searchList}>
      {data &&
        data.map((e) => {
          return (
            <li key={e.id}>
            <PlaceCard
              position={[e.longitude, e.latitude]}
              imageSrc={e.image}
              name={e.name}
              address={e.address}
              hours={`${e.openingTime} - ${e.closingTime}`}
              features={e.accessibilitys}
              showRating
              fullCard={isHighWidth}
              rating={Math.trunc(e.averageRating)}
            />
          </li>
          );
        })}
    </ul>
  );
}

export default Search;
