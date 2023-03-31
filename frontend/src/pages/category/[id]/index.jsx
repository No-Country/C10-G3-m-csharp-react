import CloseLogo from "../../../components/closeLogo/closeLogo";
import PlaceCard from "@/components/placeCard/placeCard";
import styles from "../../../scss/views/Categories/Categories.module.scss";
import { useRouter } from "next/router";

function Category() {
  const router = useRouter();
  const { id } = router.query;

  return (
    <div className={styles.container}>
      
      <div className={styles.title}>
        <h2>{id}</h2>
        <CloseLogo />
      </div>

    <ul className={styles.list}>
    {[...Array(8)].map((e, idx) => {
          return (
            <li key={idx}>
              <PlaceCard />
            </li>
          );
        })}
    </ul>

    </div>
  );
}

export default Category;
