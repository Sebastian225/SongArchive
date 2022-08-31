import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumService } from '../album.service';
import { Album } from '../Model/Album';
import { Song } from '../Model/Song';
import { SongComponent } from '../song/song.component';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export class AlbumComponent implements OnInit {

  isEditable = false;
  editingItem: Album = new Album;

  album: Album = new Album;
  hasReviews = false;

  songs: Song[] = [];
  crtSong: string = "";
  newSong: Song = new Song;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private albumService: AlbumService) { }

  isInEditMode(){
    return AlbumService.editMode;
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const albumIdFromRoute = Number(routeParams.get('id'));

    //this.album = this.albumService.fetchAlbumById(albumIdFromRoute);

    this.albumService.fetchAlbumById(albumIdFromRoute).subscribe(
      (data) => {
        this.album = data;
        if(this.album.reviews.length != 0) this.hasReviews = true;
      }
    )
  }

  addSong(){
    this.newSong = {id: 0, title: this.crtSong, albumId: 0}
    this.songs.push(this.newSong);
    this.crtSong = "";
  }

  deleteSong(valueEmitted: string){
    let deletedSong = valueEmitted;

    this.songs.forEach((element,index)=>{
      if(element.title===deletedSong) this.songs.splice(index,1);
   });
  }

  editSong(valueEmitted: SongComponent){
    let oldSongTitle = valueEmitted.title;
    let newSongTitle = valueEmitted.songName;

    this.songs.forEach((element,index)=>{
      if(element.title===oldSongTitle) this.songs[index].title = newSongTitle;
   });
  }

  async edit(){
    if(!this.isEditable){
      this.songs = this.album.songs;
      this.editingItem.id = this.album.id;
      this.editingItem.title = this.album.title;
      this.editingItem.songs = this.album.songs;
      this.editingItem.year = this.album.year;
    }
    else{
      await this.albumService.editAlbum(this.editingItem);
      alert("Album edited!");
      this.router.navigateByUrl('/', {skipLocationChange: true}).then( () => {
        setTimeout( () => {
          this.router.navigate(['album/' + Number(this.route.snapshot.paramMap.get('id'))]);
        }, 100);
      });
    }

    this.isEditable = !this.isEditable;
  }

  async delete(){
    await this.albumService.deleteAlbum(this.album);
    alert("Album deleted!")
  }

}
