import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SemesterListComponent } from './semester/components/semester-list/semester-list.component';

const routes: Routes = [
  {path: 'semester', component: SemesterListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
