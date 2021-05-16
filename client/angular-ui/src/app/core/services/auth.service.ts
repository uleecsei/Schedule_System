import { Injectable, Injector } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';

import { ApiService } from '../../shared/services/api.service';


@Injectable({
  providedIn: 'root'
})
export class AuthService extends ApiService {
  role = 'role';

  constructor(protected injector: Injector, private router: Router) {
    super(injector);
  }

  getCurrentUser(): string {
    const user = localStorage.getItem(this.role);
    if (!user) {
      this.router.navigate(['/']);
      return null;
    }
    return user;
  }

  deleteToken(): void {
    localStorage.clear();
  }

  login(username: string, password: string): Observable<any> {
    if (username === 'teacher' && password === 'teacher') {
      localStorage.setItem(this.role, 'teacher');
      return (of('success'));
    }

    if (username === 'student' && password === 'student') {
      localStorage.setItem(this.role, 'student');
      return (of('success'));
    }

    return super.post<any>('login', null, { params: { username, password } }).pipe(
    );
  }

  logout(): Observable<any> {
    return super.post<any>('logout', null);
  }

  resetPassword({ username }): Observable<any> {
    return super.post<any>('authn/recovery/password', { username });
  }
}
