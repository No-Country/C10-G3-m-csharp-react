import styles from "../../scss/views/Home/CategoryCard.module.scss";
import CircularProgress from '@mui/material/CircularProgress';

function CategorySkeleton() {
  return (
    <div className={styles.card}>
      <div className={styles.skeleton__img}><CircularProgress color="inherit" /></div>
      <div className={styles.skeleton__text}><CircularProgress /></div>
    </div>
  );
}

export default CategorySkeleton;
