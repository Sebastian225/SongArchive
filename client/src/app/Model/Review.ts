import { Album } from "./Album";
import { User } from "./User";

export class Review {
    id: number = 0;
    title: string =  "";
    description: string = ""; 
    rating: number = 0;
    album_id: number = 0
    album: Album = new Album;
    user_id: number = 0;
    user: User = new User;
}