import axios from 'axios';
import ITagData from "./models/ITagData.ts";
import {IPostsFilter} from "./models/IPostsFilter.ts";
import IFilteredPosts from "./models/IFilteredPosts.ts";

export const apiUrl = "http://localhost:5052";
export const imagesDir = apiUrl + "/Data/images/";

const postsControllerUrl = apiUrl + "/api/Posts/";
const tagsControllerUrl = apiUrl + "/api/Tags/";

export const getPostsAsync = async (filter: IPostsFilter): Promise<IFilteredPosts> => {
    const response = await axios.get<IFilteredPosts>(postsControllerUrl + "GetPage", {
        params: filter
    });
    return response.data;
}

export const getTagsAsync = async (): Promise<ITagData[]> => {
    const response = await axios.get<ITagData[]>(tagsControllerUrl + "GetAll");
    return response.data;
}