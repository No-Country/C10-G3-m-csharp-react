import CategoryCard from "../categoryCard/categoryCard";
import FeaturedCard from "../featuredCard/featuredCard";
import NearYouCard from "../nearYouCard/nearYouCard";
import styles from "../../scss/views/Home/Home.module.scss";
import CloseLogo from "../closeLogo/closeLogo";
import CategoryList from "../categoryList/categoryList";

function HomeView() {
  return (
    <div className={styles.container}>
      <div className={styles.title}>
        <h2>CATEGORÍAS</h2>
        <CloseLogo />
      </div>

      <ul className={styles.list}>

        <CategoryList/>

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
