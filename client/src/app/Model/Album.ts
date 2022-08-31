import { Review } from "./Review";
import { Song } from "./Song";

export class Album {
    id: number = 0;
    title: string =  "";
    year: number = 0; 
    songs: Song[] = [];
    image: string = "";
    reviews: Review[] = [];
}