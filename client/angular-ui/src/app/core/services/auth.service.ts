import { Injectable, Injector } from '@angular/core';
import { BehaviorSubject, EMPTY, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { ApiService } from '../../shared/services/api.service';


@Injectable({
  providedIn: 'root'
})
export class AuthService extends ApiService {
  currentUser;

  constructor(protected injector: Injector) {
    super(injector);
  }

  login({ username, password }): Observable<any> {
    return super.post<any>('login', null, { params: { username, password } }).pipe(
      tap((user) => this.currentUser)
    );
  }

  logout(): Observable<any> {
    return super.post<any>('logout', null);
  }

  resetPassword({ username }): Observable<any> {
    return super.post<any>('authn/recovery/password', { username });
  }
}
