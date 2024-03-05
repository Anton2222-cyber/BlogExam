import styles from "../modules/styles.module.css";
import {useEffect, useState} from "react";
import {getPostsAsync} from "../api/api.ts";
import IPost from "../api/models/IPost.ts";
import Post from "./post.tsx";

interface IPostsSectionProps {
    tagUrlSlug?: string
}

function PostsSection(props: IPostsSectionProps) {
    const {tagUrlSlug} = props;
    const [posts, setPosts] = useState<IPost[]>([]);

    useEffect(() => {
        setPosts([])
        loadPosts()
    }, [tagUrlSlug]);

    const loadPosts = async () => {
        try {
            const response = await getPostsAsync({
                count: 100,
                pageNumber: 1,
                tagUrlSlug: tagUrlSlug
            });

            setPosts(response.posts);
        } catch (error) {
            console.log(error);
        }
    }

    const postsList = posts.map((post) => {
        return (
            <Post key={post.id} post={post}/>
        );
    });

    return (
        <div>
            <ul className={styles.postsList}>
                {postsList}
            </ul>
        </div>
    );
}

export default PostsSection;