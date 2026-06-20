import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AboutComponent } from './components/about/about.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HistoryComponent } from './components/history/history.component';
import { ConvertComponent } from './components/convert/convert.component';
import { CompareComponent } from './components/compare/compare.component';
import { AddComponent } from './components/operations/add/add.component';
import { SubComponent } from './components/operations/sub/sub.component';
import { DivComponent } from './components/operations/div/div.component';

import { HomeComponent } from './components/home/home.component';

import { authGuard } from './guards/auth.guard';
// auth guard for protected route
export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'about', component: AboutComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [authGuard] },
  { path: 'history', component: HistoryComponent, canActivate: [authGuard] },
  { path: 'convert', component: ConvertComponent, canActivate: [authGuard] },
  { path: 'compare', component: CompareComponent, canActivate: [authGuard] },
  { path: 'operations/add', component: AddComponent, canActivate: [authGuard] },
  { path: 'operations/sub', component: SubComponent, canActivate: [authGuard] },
  { path: 'operations/div', component: DivComponent, canActivate: [authGuard] },
];
