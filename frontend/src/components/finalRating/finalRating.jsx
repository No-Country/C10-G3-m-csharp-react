import styles from "../../scss/views/Categories/FinalRating.module.scss";

function FinalRating({ rating = "" }) {
  return (
    <div className={styles.finalRating}>
      <p>Promedio</p>
      <span>{rating}</span>
      <svg
        width="11"
        height="11"
        viewBox="0 0 11 11"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          d="M5.5 8.84375L2.14844 10.875L3.03711 7.06641L0.0917969 4.50195L3.97656 4.17188L5.5 0.591797L7.02344 4.17188L10.9082 4.50195L7.96289 7.06641L8.85156 10.875L5.5 8.84375Z"
          fill="#4285F4"
        />
      </svg>
    </div>
  );
}

export default FinalRating;
