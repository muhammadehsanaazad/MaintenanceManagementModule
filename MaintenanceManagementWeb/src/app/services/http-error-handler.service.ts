import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpErrorHandlerService {
  constructor(
    private ngxSpinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) { }

  onError(error: any, source: any) {
    this.ngxSpinnerService.hide();
    this.toastrService.error('An error occurred, try again later!');

    return throwError(() => '!');
  }
}
