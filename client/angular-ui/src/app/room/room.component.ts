import { Component, OnInit } from '@angular/core';

const mockedRoomData = [
  {
    name: 'Практичне занняття.doc'
  },
  {
    name: 'Практичне занняття.pdf'
  },
  {
    name: 'Практичне занняття.gif'
  }
];

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.scss']
})
export class RoomComponent implements OnInit {
  materials = mockedRoomData;

  constructor() { }

  ngOnInit(): void {
  }

}
