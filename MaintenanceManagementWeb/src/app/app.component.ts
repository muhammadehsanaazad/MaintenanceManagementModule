import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { HeaderComponent } from './pages/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true, // add this to declare standalone component
  imports: [RouterOutlet, NgxSpinnerModule, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']  // fix plural here
})
export class AppComponent {
  title = 'MaintenanceManagementWeb';

  ngOnInit(): void {  }

}
