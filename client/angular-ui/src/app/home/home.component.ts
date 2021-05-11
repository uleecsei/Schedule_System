import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { catchError, takeUntil } from 'rxjs/operators';
import { EMPTY } from 'rxjs';


import { HomeService } from '../core/services/home.service';
import { Unsubscriber } from '../shared/unsubscriber.class';
import { ToastService } from '../core/services/toastr.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends Unsubscriber {
  someData: any;
  groupNameControl: FormControl = new FormControl();

  constructor(
    private homeService: HomeService,
    private router: Router,
    private toastr: ToastService
  ) {
    super();
  }

  onSubmit(): void {
    this.homeService.getGroupByGroupName(this.groupNameControl.value).pipe(
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
