import { Component } from '@angular/core';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../services/auth.service';
import { NavigationEnd, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [CommonModule, MatToolbarModule, MatButtonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  //#region Properties

  fullName: string | null | undefined;
  //#endregion

  //#region Initialization

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.router.events.subscribe((event: any) => {
      if (event instanceof NavigationEnd) {
        this.OnRouteChange();
      }
    });
  }


  //#endregion

  //#region Methods

  OnRouteChange() {
    this.fullName = localStorage.getItem('fullName');
  }

  Logout() {
    this.authService.Logout();
  }
  //#endregion
}
