import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../../services/auth.service';
import { AuthForm } from '../../../form-groups/auth-form';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  //#region Properties

  //#endregion

  //#region Initialization

  constructor(
    public authForm: AuthForm,
    private router: Router,
    private toastr: ToastrService,
    private authService: AuthService
  ) { }

  ngOnInit(): void { }
  //#endregion

  //#region Methods

  Login() {
    if (this.authForm.loginForm.valid) {
      this.authService
        .Login(this.authForm.loginForm.value)
        .subscribe((response: any) => {
          if (response) {
            if (response.body.roles[0] === 'Admin') {
              localStorage.setItem('token', response.body.token);
              localStorage.setItem('role', response.body.roles[0]);
              localStorage.setItem('id', response.body.id);
              localStorage.setItem('fullName', response.body.fullName);
              this.router.navigate(['/services']);
            }
            else {
              this.toastr.error('You are not authorized to perform this operation!');
            }
          }
        });
    }
  }
  //#endregion
}
