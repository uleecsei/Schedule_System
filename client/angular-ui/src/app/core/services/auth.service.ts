import { Injectable, Injector } from '@angular/core';
import { Observable, of } from 'rxjs';
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

  login(username: string, password: string): Observable<any> {
    // return super.post<any>('login', null, { params: { username, password } }).pipe(
    //   tap((user) => this.currentUser)
    // );
    return of(123);
  }

  logout(): Observable<any> {
    return super.post<any>('logout', null);
  }

  resetPassword({ username }): Observable<any> {
    return super.post<any>('authn/recovery/password', { username });
  }
}
