import CloseLogo from "../../../components/closeLogo/closeLogo";
import PlaceCard from "@/components/placeCard/placeCard";
import styles from "../../../scss/views/Categories/Categories.module.scss";
import useHighWidth from "@/utils/useHighWidth";

function Category(props) {
  const places = props?.category?.establishments;

  const isHighWidth = useHighWidth()

  return (
    <div className={styles.container}>
      <div className={styles.title}>
        <h2>{props?.category?.name}</h2>
        <CloseLogo />
      </div>

      <ul className={styles.list}>
        {places?.map((e) => {
          return (
            <li key={e.id}>
              <PlaceCard
                position={[e.longitude, e.latitude]}
                imageSrc={e.image}
                name={e.name}
                address={e.address}
                hours={"11:30am - 11:00pm"}
                features={e.accessibilitys}
                showRating
                fullCard={isHighWidth}
                rating={e.averageRating}
              />
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export async function getStaticPaths() {
  return {
    paths: [{ params: { id: "56440f82-794a-447a-9b9b-08db3b979424" } }],
    fallback: true,
  };
}

export async function getStaticProps({ params }) {
  const catData = await fetch(
    `https://inclusive-001-site1.atempurl.com/api/category/${params.id}`
  );

  const category = await catData.json();

  return {
    props: { category },
  };
}

export default Category;
