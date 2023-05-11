import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SemesterplannerContentComponent } from '../dashboard/semesterplanner-content/semesterplanner-content.component';
import { SemesterPlannerFormDialogComponent } from './semesterplanner-form-dialog/semesterplanner-form-dialog.component';
import { MaterialModule } from 'src/app/material.module';
import { SemesterplannerDeleteDialogComponent } from './semesterplanner-delete-dialog/semesterplanner-delete-dialog.component';
import { InformationsModule } from 'src/app/shared/components/informations/informations.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    InformationsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    SemesterplannerDeleteDialogComponent,
    SemesterPlannerFormDialogComponent
  ],
  exports: [
    SemesterplannerDeleteDialogComponent,
    SemesterPlannerFormDialogComponent
  ],
})
export class SemesterplannerModule { }
