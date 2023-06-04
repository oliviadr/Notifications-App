import { Category } from "./category";

export interface Announcement {
    title: string,
    author: string,
    message: string,
    categoryId :string,
    imageUrl:string,
    id:string
}
