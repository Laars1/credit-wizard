import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SemesterListComponent } from './core/semester/semester-list/semester-list.component';
import { SigninComponent } from './core/sign-in/sign-in.component';
import { AuthGuard } from './shared/security/auth.guard';
import { ModulListComponent } from './core/modul/modul-list/modul-list-component';
import { DegreeListComponent } from './core/degree/degree-list/degree-list-component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: SigninComponent },
  { path: 'semester', component: SemesterListComponent, canActivate: [AuthGuard] },
  { path: 'modules', component: ModulListComponent, canActivate: [AuthGuard] },
  { path: 'degree', component: DegreeListComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
