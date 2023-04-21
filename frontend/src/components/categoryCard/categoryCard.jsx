import Link from "next/link";
import styles from "../../scss/views/Home/CategoryCard.module.scss";
import Image from "next/image";

function CategoryCard({data}) {
  return (
    <div className={styles.card}>
      <div className={styles.img}>
        <Image alt={`${data.name.toLowerCase()} photo`} src={data.image} width={140} height={80} />
      </div>
      <div className={styles.text}>
        <h3>{data.name}</h3>
        <p>{`${data.establishments.length} establecimientos`}</p>
        <Link href={`/category/${data.id}`}>Ver listado</Link>
      </div>
    </div>
  );
}

export default CategoryCard;
