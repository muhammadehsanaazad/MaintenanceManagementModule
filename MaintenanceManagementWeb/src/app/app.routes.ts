import { Routes } from '@angular/router';

import { LoginComponent } from './pages/auth/login/login.component';
import { ServicesComponent } from './pages/admin/services/services.component';
import { ServiceTaskComponent } from './pages/admin/service-task/service-task.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { AuthGuard } from './guard/auth-guard';

export const appRoutes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },

  {
    path: 'services',
    canActivate: [AuthGuard],
    component: ServicesComponent
  },
  {
    path: 'service-task/:id',
    canActivate: [AuthGuard],
    component: ServiceTaskComponent
  },

  { path: '**', component: PageNotFoundComponent }
];
