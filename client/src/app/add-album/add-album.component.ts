import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AlbumService } from '../album.service';
import { Album } from '../Model/Album';
import { Song } from '../Model/Song';
import { SongComponent } from '../song/song.component';

@Component({
  selector: 'app-add-album',
  templateUrl: './add-album.component.html',
  styleUrls: ['./add-album.component.css']
})
export class AddAlbumComponent implements OnInit {

  songs: Song[] = [];
  crtSong = '';
  album: Album = new Album;
  newSong: Song = new Song;

  albumForm = new FormGroup({
    title: new FormControl(''),
    year: new FormControl(''),
    image: new FormControl(''),
  });

  constructor(private albumService: AlbumService) { }

  ngOnInit(): void {
  }

  async onSubmit() {
    // TODO: Use EventEmitter with form value
    this.album = this.albumForm.value;
    this.album.songs = this.songs;
    console.log(this.album);

    await this.albumService.addAlbum(this.album);
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

}
