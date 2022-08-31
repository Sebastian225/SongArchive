import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Review } from '../Model/Review';
import { ReviewService } from '../review.service';
import { RatingPipe } from '../rating.pipe';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  review: Review = new Review;
  isEditable = false;

  editingItem: Review = new Review;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private reviewService : ReviewService
  ) { }

  isInEditMode(){
    return ReviewService.editMode;
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const reviewIdFromRoute = Number(routeParams.get('id'));

    this.reviewService.fetchReviewById(reviewIdFromRoute).subscribe(
      (data) => {this.review = data;}
    )
  }

  async edit(){
    if(!this.isEditable){
      this.editingItem.id = this.review.id;
      this.editingItem.title = this.review.title;
      this.editingItem.description = this.review.description;
      this.editingItem.rating = this.review.rating;
      this.editingItem.album_id = this.review.album_id;
      this.editingItem.user_id = this.review.user_id;
    }
    else{
      await this.reviewService.editReview(this.editingItem);
      alert("Review edited!");
      this.router.navigateByUrl('/', {skipLocationChange: true}).then( () => {
        setTimeout( () => {
          this.router.navigate(['review/' + Number(this.route.snapshot.paramMap.get('id'))]);
        }, 100);
      });
    }

    this.isEditable = !this.isEditable;
  }

  async delete(){
    await this.reviewService.deleteReview(this.review);
    alert("Review deleted!")
  }

  formatLabel(value: number) {

    return value;
  }

}
