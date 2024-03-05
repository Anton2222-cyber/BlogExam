import styles from '../modules/styles.module.css';
import {useEffect, useState} from "react";
import {getTagsAsync} from "../api/api.ts";
import ITagData from "../api/models/ITagData.ts";
import {useNavigate} from "react-router-dom";

function TagsSection() {
    const [tags, setTags] = useState<ITagData[]>([]);
    const navigate = useNavigate();

    useEffect(() => {
        loadTags();
    }, []);

    const loadTags = async () => {
        try {
            const response = await getTagsAsync();

            setTags(response);
        } catch (error) {
            console.log(error);
        }
    }

    const tagsList = tags.map((tag) => {
        return (
            <li key={tag.id}><a onClick={() => navigate(`/tag/${tag.urlSlug}`)}>{tag.name}</a></li>
        );
    });

    return (
        <div>
            <h2 className={styles.subHeader}>Теги</h2>

            <ul className={styles.tagsList}>
                {tagsList}
            </ul>
        </div>
    );
}

export default TagsSection;