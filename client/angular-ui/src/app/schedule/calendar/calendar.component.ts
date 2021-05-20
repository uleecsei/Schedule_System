import { Component } from '@angular/core';
import { getWeek } from 'date-fns';

import { CalendarMonthViewBeforeRenderEvent, CalendarView } from 'angular-calendar';
import { ScheduleService } from '../../core/services/schedule.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent{
  viewDate = new Date();
  view: CalendarView = CalendarView.Month;

  customHeaderDays = ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Нд'];
  monthList = ['Січень', 'Лютий', 'Березень', 'Квітень', 'Травень',
    'Червень', 'Липень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень'];
  currentMonthIndex = new Date().getMonth();
  displayedMonthIndex = this.currentMonthIndex;

  constructor(private scheduleService: ScheduleService) {
  }

  beforeMonthViewRender(event: CalendarMonthViewBeforeRenderEvent): void {
    this.setStylesForCurrentWeek(event);
    this.scheduleService.currentWeek.next(getWeek(this.viewDate));
  }

  onDayClick(event): void {
    this.viewDate = event.date;
  }

  setStylesForCurrentWeek(event: CalendarMonthViewBeforeRenderEvent): void {
    event.body.forEach((monthViewDay) => {
      if (event.header.some((weekDay) => monthViewDay.date.toUTCString() === weekDay.date.toUTCString())){
        monthViewDay.cssClass = 'current-week';
      }
    });
  }

  onNextMonth(): void{
    this.displayedMonthIndex++;
  }

  onPreviousMonth(): void{
    this.displayedMonthIndex--;
  }
}
