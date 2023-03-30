import CategoryCard from "../categoryCard/categoryCard";
import FeaturedCard from "../featuredCard/featuredCard";
import NearYouCard from "../nearYouCard/nearYouCard";
import styles from "../../scss/views/Home/Home.module.scss";

function HomeView() {
  return (
    <div className={styles.container}>
      <h2 className={styles.title}>CATEGORÍAS</h2>

      <ul className={styles.list}>
        {["", "", "", "", "", "", "", ""].map((e, idx) => {
          return (
            <li key={idx}>
              <CategoryCard />
            </li>
          );
        })}
        <li className={styles.featured}>
          <FeaturedCard />
        </li>
        <li className={styles.nearyou}>
          <NearYouCard/>
        </li>
      </ul>
    </div>
  );
}

export default HomeView;
