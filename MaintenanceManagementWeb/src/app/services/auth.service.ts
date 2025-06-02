import { Injectable } from '@angular/core';

import { BackendService } from './backend.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private backendService: BackendService,
    private router: Router,
  ) { }

  GetToken() {
    return localStorage.getItem('token');
  }

  Login(requestBody: any) {
    return this.backendService.Post(
      'Auth',
      requestBody
    );
  }

  Logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('id');
    localStorage.removeItem('fullName');
    this.router.navigate(['/login']);
  }
}
