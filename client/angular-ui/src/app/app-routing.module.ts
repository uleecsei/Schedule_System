import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RoomComponent } from './room/room.component';
import { AuthComponent } from './auth/auth.component';
import { SilabusComponent } from './silabus/silabus.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth',
    pathMatch: 'full'
  },
  {
    path: 'auth',
    component: AuthComponent
  },
  {
    path: 'schedule',
    loadChildren: () => import('./schedule/schedule.module').then((s) => s.ScheduleModule)
  },
  {
    path: 'room',
    component: RoomComponent
  },
  {
    path: 'silabus',
    component: SilabusComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
