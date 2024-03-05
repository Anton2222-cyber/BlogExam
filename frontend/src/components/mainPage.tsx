import TagsSection from "./tagsSection.tsx";
import styles from '../modules/styles.module.css';
import PostsSection from "./postsSection.tsx";
import {useNavigate, useParams} from "react-router-dom";


function MainPage() {
    const {tagUrlSlug} = useParams();
    const navigate = useNavigate();

    return (
        <div className={styles.body}>
            <h1 className={styles.header} onClick={() => navigate(`/`)}>Блог</h1>
            <div className={styles.contentBody}>
                <section>
                    <PostsSection tagUrlSlug={tagUrlSlug}/>
                </section>
                <section className={styles.tagsSection}>
                    <TagsSection/>
                </section>
            </div>
        </div>
    )
        ;
}

export default MainPage;