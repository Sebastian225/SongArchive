import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAlbumComponent } from './add-album/add-album.component';
import { AlbumComponent } from './album/album.component';
import { AlbumsComponent } from './albums/albums.component';
import { HomeComponent } from './home/home.component';
import { ReviewComponent } from './review/review.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { WriteReviewComponent } from './write-review/write-review.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'albums', component: AlbumsComponent},
  {path: 'album/:id', component: AlbumComponent},
  {path: 'add', component: AddAlbumComponent},
  {path: 'reviews/:id', component: ReviewsComponent},
  {path: 'review/:id', component: ReviewComponent},
  {path: 'write-review', component: WriteReviewComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
