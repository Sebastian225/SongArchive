import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../album.service';
import { Album } from '../Model/Album';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})

export class AlbumsComponent implements OnInit {

  albumList: Album[] = [];

  constructor(private albumService : AlbumService) { }

  ngOnInit(): void {
    this.albumService.fetchAlbums().subscribe(
      (data) => {
        this.albumList = data;
      }
    )
  }

}



