import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Review } from '../Model/Review';
import { ReviewService } from '../review.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {

  reviews: Review[] = [];

  constructor(
    private route: ActivatedRoute,
    private reviewService : ReviewService
  ) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const albumIdFromRoute = Number(routeParams.get('id'));

    this.reviewService.fetchReviewsForAlbum(albumIdFromRoute).subscribe(
      (data) => {this.reviews = data;}
    );
  }
}
