import ITagData from "./ITagData.ts";

export default interface IPost {
    id: number;
    title: string;
    shortDescription: string;
    description: string;
    meta: string;
    urlSlug: string;
    published: boolean;
    postedOn: Date;
    modified: Date | null;
    tags: ITagData[];
}
