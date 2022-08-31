import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AlbumService } from '../album.service';
import { Album } from '../Model/Album';
import { Review } from '../Model/Review';
import { ReviewService } from '../review.service';

@Component({
  selector: 'app-write-review',
  templateUrl: './write-review.component.html',
  styleUrls: ['./write-review.component.css']
})
export class WriteReviewComponent implements OnInit {

  albums: Album[] = [];
  review: Review = new Review;
  
  reviewForm = new FormGroup({
    title: new FormControl(''),
    description: new FormControl(''),
    album_name: new FormControl(''),
    rating:  new FormControl()
  });

  constructor(
    private reviewService: ReviewService,
    private albumService: AlbumService  
  ) {
    this.albumService.fetchAlbums().subscribe(
      (data) => {
        this.albums = data.reverse();
      }
    )
   }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    //console.log(this.reviewForm.value);
    
    this.review = this.reviewForm.value;
    let albumByName = this.albums.find(album => album.title === this.reviewForm.controls["album_name"].value);

    if(albumByName){
      this.review.album_id = albumByName.id;
    }

    //TODO ADD USER
    this.review.user_id = 2;

    this.reviewService.addReview(this.review);
  }

  ngOnInit(): void {
    
  }

  formatLabel(value: number) {

    return value;
  }

}
