import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { takeUntil } from 'rxjs/operators';

import { ScheduleService } from '../../core/services/schedule.service';
import { Unsubscriber } from '../../shared/unsubscriber.class';

const mockedWeek1 = [
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

const mockedWeek2 = [
  {
    name: 'Понеділок',
    lessons: [
      { name: 'Фізика' },
      { name: 'Фізика' }
    ]
  },
  {
    name: 'Вівторок',
    lessons: [
      { name: 'Англ.мова' },
      { name: 'ФП' },
      { name: 'ФП' }
    ]
  },
  {
    name: 'Середа',
    lessons: [
    ]
  },
  {
    name: 'Четвер',
    lessons: [
      { name: 'БД' },
      { name: 'БД' },
      { name: 'Вища математика' },
    ]
  },
  {
    name: 'П\'ятниця',
    lessons: [
      { name: 'Хімія' }
    ]
  },
  {
    name: 'Субота',
    lessons: [
    ]
  },
];


@Component({
  selector: 'app-week',
  templateUrl: './week.component.html',
  styleUrls: ['./week.component.scss']
})
export class WeekComponent extends Unsubscriber implements OnInit {
  week;

  constructor(
    private router: Router,
    private scheduleService: ScheduleService) {
    super();
  }

  ngOnInit(): void {
    this.scheduleService.currentWeek.pipe(
      takeUntil(this.unsubscribe)
    ).subscribe((week) => {
      this.week = week % 2 === 0 ? mockedWeek1 : mockedWeek2;
    });
  }

  onRoomEnter(): void {
    this.router.navigate(['room']);
  }
}
