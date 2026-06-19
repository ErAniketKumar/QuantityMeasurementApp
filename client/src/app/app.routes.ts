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

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'about', component: AboutComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'history', component: HistoryComponent },
  { path: 'convert', component: ConvertComponent },
  { path: 'compare', component: CompareComponent },
  { path: 'operations/add', component: AddComponent },
  { path: 'operations/sub', component: SubComponent },
  { path: 'operations/div', component: DivComponent },
];
