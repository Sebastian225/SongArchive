import { Directive, OnInit, Input } from '@angular/core';

@Directive({
  selector: '[appSongName]'
})
export class SongNameDirective implements OnInit {

  // @Input('appSongName')
  // title: '';

  constructor() { }

  ngOnInit(): void {
    
  }

}
