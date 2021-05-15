import { Injectable, Injector } from '@angular/core';
import { Subject } from 'rxjs';

import { ApiService } from '../../shared/services/api.service';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService extends ApiService{
  currentWeek: Subject<number> = new Subject<number>();

  constructor(protected injector: Injector) {
    super(injector);
  }
}
