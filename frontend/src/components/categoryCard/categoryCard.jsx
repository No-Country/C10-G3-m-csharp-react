import Link from "next/link";
import styles from "../../scss/views/Home/CategoryCard.module.scss";

function CategoryCard() {
  return (
    <div className={styles.card}>
      <div className={styles.img}></div>
      <div className={styles.text}>
        <h3>RESTAURANTES</h3>
        <p>15 establecimientos</p>
        <Link href="/">Ver listado</Link>
      </div>
    </div>
  );
}

export default CategoryCard;
