import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Importing components to be used as routes
import { SemesterListComponent } from './core/semester/semester-list/semester-list.component';
import { SigninComponent } from './core/sign-in/sign-in.component';
import { AuthGuard } from './shared/security/auth.guard';
import { DashboardComponent } from './core/dashboard/dashboard.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { ModulListComponent } from './core/modul/modul-list/modul-list-component';
import { DegreeListComponent } from './core/degree/degree-list/degree-list-component';

// Define all the routes
const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: SigninComponent },
  {
    path: 'semester',
    component: SemesterListComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
  },
  { path: 'modules', component: ModulListComponent, canActivate: [AuthGuard] },
  { path: 'degree', component: DegreeListComponent, canActivate: [AuthGuard] },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },
];

@NgModule({
  // Configure the router module with the defined routes and options
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],

  // Export the router module so that it can be imported by other modules
  exports: [RouterModule],
})
export class AppRoutingModule {}
