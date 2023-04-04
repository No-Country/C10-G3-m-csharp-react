import Link from "next/link";
import styles from "../../scss/views/Home/CategoryCard.module.scss";

function CategoryCard({data}) {
  return (
    <div className={styles.card}>
      <div className={styles.img}></div>
      <div className={styles.text}>
        <h3>{data.name}</h3>
        <p>15 establecimientos</p>
        <Link href={`/category/${data.name.toLowerCase()}`}>Ver listado</Link>
      </div>
    </div>
  );
}

export default CategoryCard;
