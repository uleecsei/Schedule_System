import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

import { ScheduleComponent } from './schedule.component';


@NgModule({
  declarations: [ScheduleComponent],
  imports: [
    CommonModule,
    CalendarModule.forRoot({ provide: DateAdapter, useFactory: adapterFactory }),
    RouterModule.forChild([{
      path: '',
      component: ScheduleComponent
    }])
  ]
})
export class ScheduleModule { }
