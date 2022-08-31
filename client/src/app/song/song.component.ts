import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent implements OnInit {
  @Output() deleteSongEvent: EventEmitter<string> = new EventEmitter<string>();
  @Output() editSongEvent: EventEmitter<SongComponent> = new EventEmitter<SongComponent>();
  @Input() title: string = "";

  isEditing = false;
  songName: string = "";

  constructor() { }

  ngOnInit(): void {
    this.songName = this.title;
  }

  editSong(){
    this.editSongEvent.emit(this);
    this.isEditing = !this.isEditing;
  }

  deleteSong(){
    this.deleteSongEvent.emit(this.title);
  }

}
