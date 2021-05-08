import { Injectable, Injector } from '@angular/core';
import { Observable, of } from 'rxjs';

import { ApiService } from '../../shared/services/api.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService extends ApiService{

  constructor(protected injector: Injector) {
    super(injector);
  }

  getGroup(groupName: string): Observable<any> {
    const cleanGroupName = groupName.trim().toLowerCase();
    if (cleanGroupName === 'тр-71') {
      return of(123);
    }
    return super.get('');
  }

}
