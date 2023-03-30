import CategoryCard from "../categoryCard/categoryCard";
import FeaturedCard from "../featuredCard/featuredCard";
import styles from "../../scss/views/Home/Home.module.scss";

function HomeView() {
  return (
    <div className={styles.container}>
      <h2 className={styles.title}>CATEGORÍAS</h2>

      <ul className={styles.list}>
        {["", "", ""].map((e, idx) => {
          return <li key={idx}><CategoryCard /></li>;
        })}
      </ul>

      <FeaturedCard />
    </div>
  );
}

export default HomeView;
