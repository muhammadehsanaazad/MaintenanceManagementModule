import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router
  ) { }

  canActivate(_route: ActivatedRouteSnapshot, _state: RouterStateSnapshot) {

    const token = localStorage.getItem('token');
    if (token) {
      const role = localStorage.getItem('role');
      if (role && role === 'Admin') {
        // authorised so return true
        return true;
      }
      else {
        // not authorised so return false
        this.router.navigate(['/login']);
        return false;
      }
    }
    else {
      // not authorised so return false
      this.router.navigate(['/login']);
      return false;
    }
  }
}
