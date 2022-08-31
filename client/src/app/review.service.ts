import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AlbumService } from './album.service';
import { Review } from './Model/Review';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  static editMode: boolean = true;

  constructor(private httpClient: HttpClient,
              private albumService : AlbumService
              ) { }

  fetchReviews() {
    return this.httpClient.get<Review[]>("https://localhost:44391/api/Review");
  }
            
  fetchReviewById(id: number){
    return this.httpClient.get<Review>("https://localhost:44391/api/Review/" + id);
  }

  fetchReviewsForAlbum(id: number){
    return this.httpClient.get<Review[]>("https://localhost:44391/api/Review/album/" + id);
  }
            
  async addReview(review: Review) {
    this.httpClient.post("https://localhost:44391/api/Review/", review).subscribe(
      response => {
      console.log(response);
    }
    );
  }

  async editReview(review: Review) {
    this.httpClient.patch("https://localhost:44391/api/Review/" + review.id, review).subscribe(
      response => {
        console.log(response);
      }
    )
  }

  async deleteReview(review: Review){
    this.httpClient.delete("https://localhost:44391/api/Review/" + review.id).subscribe(
      response => {
        console.log(response);
      }
    );
  }

}
