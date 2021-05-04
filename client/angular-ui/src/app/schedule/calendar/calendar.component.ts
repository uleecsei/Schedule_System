import { Component } from '@angular/core';

import { CalendarMonthViewBeforeRenderEvent, CalendarView } from 'angular-calendar';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent {
  viewDate = new Date();
  view: CalendarView = CalendarView.Month;

  customHeaderDays = ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Нд'];
  monthList = ['Січень', 'Лютий', 'Березень', 'Квітень', 'Травень',
    'Червень', 'Липень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень'];
  currentMonthIndex = new Date().getMonth();
  displayedMonthIndex = this.currentMonthIndex;

  beforeMonthViewRender(event: CalendarMonthViewBeforeRenderEvent): void {
    this.setStylesForCurrentWeek(event);
  }

  setStylesForCurrentWeek(event: CalendarMonthViewBeforeRenderEvent): void {
    if (!event.header.some(weekDay => weekDay.isToday)){
      return;
    }
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
