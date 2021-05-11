import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

const mockedWeek = [
  {
    name: 'Понеділок',
    lessons: [
      { name: 'Мат. Аналіз' }
    ]
  },
  {
    name: 'Вівторок',
    lessons: [
      { name: 'Мат. Аналіз' },
      { name: 'ФП' },
      { name: 'Алгор. та структ.' }
    ]
  },
  {
    name: 'Середа',
    lessons: [
      { name: 'Мат. Аналіз' },
      { name: 'ФП' },
      { name: 'Алгор. та структ.' }
    ]
  },
  {
    name: 'Четвер',
    lessons: [
      { name: 'Мат. Аналіз' },
      { name: 'Мат. Аналіз' },
      { name: 'ФП' },
    ]
  },
  {
    name: 'П\'ятниця',
    lessons: [
    ]
  },
  {
    name: 'Субота',
    lessons: [
      { name: 'Мат. Аналіз' }
    ]
  },
];


@Component({
  selector: 'app-week',
  templateUrl: './week.component.html',
  styleUrls: ['./week.component.scss']
})
export class WeekComponent implements OnInit {
  week = mockedWeek;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onRoomEnter(): void {
    this.router.navigate(['room']);
  }
}
