import { HttpInterceptorFn } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth.service';
import { catchError, throwError } from 'rxjs';

export const HttpResponseInterceptor: HttpInterceptorFn = (req, next) => {
  const toastr = inject(ToastrService);
  const authService = inject(AuthService);

  const token = localStorage.getItem('token') || '';
  const isFileUpload = req.headers.has('isFile');

  const customReq = req.clone({
    headers: isFileUpload
      ? req.headers.set('Authorization', `Bearer ${token}`)
      : req.headers
          .append('Content-Type', 'application/json')
          .append('Authorization', `Bearer ${token}`),
  });

  return next(customReq).pipe(
    catchError((response: HttpErrorResponse) => {
      if (response.status === 403) {
        toastr.error('You are not allowed to perform this action!');
      } else if (response.status === 401) {
        authService.Logout();
      }
      return throwError(() => response.error?.message || response.statusText);
    })
  );
};
