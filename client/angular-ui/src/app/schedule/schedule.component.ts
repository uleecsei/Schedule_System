import { Component, OnInit } from '@angular/core';
import { CalendarMonthViewBeforeRenderEvent } from 'angular-calendar';


@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: [ './schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  viewDate = new Date();

  constructor() { }

  ngOnInit(): void {
  }


  beforeMonthViewRender(event: CalendarMonthViewBeforeRenderEvent): void {
    event.body.forEach((day) => {
      if (event.header.some((day2) => day.date.toUTCString() === day2.date.toUTCString())){
        day.cssClass = 'red';
        console.log(day);
      }
    });

  }
}
