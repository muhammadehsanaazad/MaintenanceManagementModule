import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { HttpErrorHandlerService } from './http-error-handler.service';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../environments/environment.prod';
import { catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackendService {


  constructor(
    private httpClient: HttpClient,
    private ngxSpinnerService: NgxSpinnerService,
    private httpErrorHandlerService: HttpErrorHandlerService,
    private toastrService: ToastrService
  ) { }

  Post(url: string, requestBody: any) {
    this.ngxSpinnerService.show();
    return this.httpClient.post(environment.APIBaseUrl + url, requestBody).pipe(
      map((response: any) => {
        this.ngxSpinnerService.hide();
        if (response.success) return response;
        else {
          this.toastrService.warning(response.message);
          return null;
        }
      }),
      catchError((error: any, source: any) => this.httpErrorHandlerService.onError(error, source))
    );
  }

  Get(url: string) {
    this.ngxSpinnerService.show();
    return this.httpClient.get(environment.APIBaseUrl + url).pipe(
      map((response: any) => {
        this.ngxSpinnerService.hide();
        if (response.success) return response;
        else {
          this.toastrService.warning(response.message);
          return null;
        }
      }),
      catchError((error: any, source: any) => this.httpErrorHandlerService.onError(error, source))
    );
  }

    Put(url: string, requestBody: any) {
    this.ngxSpinnerService.show();
    return this.httpClient.put(environment.APIBaseUrl + url, requestBody).pipe(
      map((response: any) => {
        this.ngxSpinnerService.hide();
        if (response.success) return response;
        else {
          this.toastrService.warning(response.message);
          return null;
        }
      }),
      catchError((error: any, source: any) => this.httpErrorHandlerService.onError(error, source))
    );
  }

  Delete(url: string) {
    this.ngxSpinnerService.show();
    return this.httpClient.delete(environment.APIBaseUrl + url).pipe(
      map((response: any) => {
        this.ngxSpinnerService.hide();
        if (response.success) return response;
        else {
          this.toastrService.warning(response.message);
          return null;
        }
      }),
      catchError((error: any, source: any) => this.httpErrorHandlerService.onError(error, source))
    );
  }
}
