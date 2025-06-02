import { bootstrapApplication } from '@angular/platform-browser';
import { importProvidersFrom } from '@angular/core';
import { AppComponent } from './app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';
import { appRoutes } from './app/app.routes';
import { provideRouter, RouterModule } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { HttpResponseInterceptor } from './app/interceptor/http-response-interceptor';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom(MatNativeDateModule, MatDatepickerModule),
    provideRouter(appRoutes),
    importProvidersFrom(BrowserAnimationsModule),
    provideToastr(),
    provideHttpClient(withInterceptors([HttpResponseInterceptor]))

  ]
}).catch(err => console.error(err));
