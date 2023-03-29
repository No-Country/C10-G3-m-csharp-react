import CategoryCard from '../categoryCard/categoryCard';
import FeaturedCard from '../featuredCard/featuredCard';
import styles from '../../scss/views/Home/Home.module.scss'

function HomeView() {
    return ( 
        <div className={styles.container}>
            <h2 className={styles.title}>CATEGORÍAS</h2>

            { ['','',''].map((e, idx) => {
                return (
                    <CategoryCard key={idx}/>
                )
            }) }

            <FeaturedCard />

        </div>
     );
}

export default HomeView;