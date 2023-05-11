import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { DashboardProgressBarComponent } from './dashboard-progress-bar/dashboard-progress-bar.component';
import { SemesterplannerContentComponent } from './semesterplanner-content/semesterplanner-content.component';
import { SemesterplannerOverviewComponent } from './semesterplanner-overview/semesterplanner-overview.component';
import { UserInformationComponent } from './user-information/user-information.component';
import { MaterialModule } from 'src/app/material.module';
import { InformationsModule } from 'src/app/shared/components/informations/informations.module';
import { DegreeProgressComponent } from './degree-progress/degree-progress.component';
import { SemesterplannerModule } from '../semesterplanner/semesterplanner.module';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    InformationsModule,
    SemesterplannerModule
  ],
  declarations: [
    DashboardComponent,
    DashboardProgressBarComponent,
    DegreeProgressComponent,
    SemesterplannerContentComponent,
    SemesterplannerOverviewComponent,
    UserInformationComponent
  ],
  exports: [
    DashboardComponent
  ],
})
export class DashboardModule { }
