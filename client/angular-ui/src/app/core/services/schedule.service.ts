import { Injectable, Injector } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { ApiService } from '../../shared/services/api.service';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService extends ApiService{
  currentWeek: Subject<number> = new Subject<number>();

  constructor(protected injector: Injector, private http: HttpClient) {
    super(injector);
  }

  getAllFiles(): Observable<any> {
    return this.http.get('');
  }

  postFile(name: string, fileLink: string): Observable<any> {
    return this.post('', {name, fileLink});
  }
}
