import IPost from "../api/models/IPost.ts";
import styles from '../modules/styles.module.css';
import stc from "string-to-color";
import {useNavigate} from "react-router-dom";

interface IPostProps {
    post: IPost
}

const makeColorBrighter = (color: number) => (color < 160) ? (color + 160) : (color);

const textToColor = (text: string) => {
    const color = stc(text);

    const hexR = color.substring(1, 3);
    let r = parseInt(hexR, 16);
    r = makeColorBrighter(r);

    const hexG = color.substring(3, 5);
    let g = parseInt(hexG, 16);
    g = makeColorBrighter(g);

    const hexB = color.substring(5, 7);
    let b = parseInt(hexB, 16);
    b = makeColorBrighter(b);


    return `rgb(${r},${g},${b})`;
}

function Post(props: IPostProps) {
    const {post} = props
    const navigate = useNavigate()

    return (
        <div className={styles.postContainer}>
            <p className={styles.postTitle}>{post.title}</p>
            <p>{post.shortDescription}</p>
            <div className={styles.postTags}>
                <ul>
                    {post.tags.map((tag) => <li key={tag.id}
                                                onClick={() => navigate(`/tag/${tag.urlSlug}`)}
                                                style={{backgroundColor: textToColor(tag.name)}}>{tag.name}</li>)}
                </ul>
            </div>
            <div className={styles.postInfo}>
                <ul>
                    <li>Опубліковано: {new Date(post.postedOn).toLocaleDateString('uk-UA')}</li>
                    {post.modified && <li>Редаговано: {new Date(post.modified).toLocaleDateString('uk-UA')}</li>}
                </ul>
            </div>
        </div>
    );
}

export default Post;