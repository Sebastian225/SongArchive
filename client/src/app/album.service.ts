import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album } from './Model/Album';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  static editMode: boolean = true;

  constructor(private httpClient: HttpClient) { }

  fetchAlbums() {
    return this.httpClient.get<Album[]>("https://localhost:44391/api/Album");
  }

  fetchAlbumById(id: number){
    return this.httpClient.get<Album>("https://localhost:44391/api/Album/" + id);
  }

  async addAlbum(album: Album) {
    this.httpClient.post("https://localhost:44391/api/Album/", album).subscribe(
      response => {
        console.log(response);
      }
    );
  }

  async editAlbum(album: Album) {
    this.httpClient.put("https://localhost:44391/api/Album/" + album.id, album).subscribe(
      response => {
        console.log(response);
      }
    )
  }

  async deleteAlbum(album: Album){
    this.httpClient.delete("https://localhost:44391/api/Album/" + album.id).subscribe(
      response => {
        console.log(response);
      }
    );
  }

}

