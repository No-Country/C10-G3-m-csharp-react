import CategoryCard from "../categoryCard/categoryCard";
import FeaturedCard from "../featuredCard/featuredCard";
import NearYouCard from "../nearYouCard/nearYouCard";
import styles from "../../scss/views/Home/Home.module.scss";
import CloseLogo from "../closeLogo/closeLogo";

function HomeView() {
  return (
    <div className={styles.container}>
      <div className={styles.title}>
        <h2>CATEGORÍAS</h2>
        <CloseLogo />
      </div>

      <ul className={styles.list}>
        {[...Array(8)].map((e, idx) => {
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
          <NearYouCard />
        </li>
      </ul>
    </div>
  );
}

export default HomeView;
