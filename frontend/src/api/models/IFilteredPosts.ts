import IPost from "./IPost.ts";

export default interface IFilteredPosts {
    posts: IPost[];
    pagesCount: number;
}