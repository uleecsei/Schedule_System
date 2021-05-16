import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { catchError, takeUntil } from 'rxjs/operators';
import { EMPTY } from 'rxjs';

import { ToastService } from '../core/services/toastr.service';
import { Unsubscriber } from '../shared/unsubscriber.class';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent extends Unsubscriber{
  someData: any;
  name: FormControl = new FormControl();
  password: FormControl = new FormControl();

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastService
  ) {
    super();
  }

  onSubmit(): void {
    this.authService.login(this.name.value, this.password.value).pipe(
      takeUntil(this.unsubscribe),
      catchError((err) => {
        this.toastr.openSnackBar(err.message, 'Помилка сервера');
        return EMPTY;
      })
    ).subscribe((someData) => {
      this.someData = someData;
      this.router.navigate(['/schedule']);
    });
  }
}
