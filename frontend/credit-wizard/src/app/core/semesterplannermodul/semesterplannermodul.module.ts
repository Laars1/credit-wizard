import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material.module';
import { InformationsModule } from 'src/app/shared/components/informations/informations.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SemesterplannermodulFormDialogComponent } from './semesterplannermodul-form-dialog/semesterplannermodul-form-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    InformationsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    SemesterplannermodulFormDialogComponent
  ],
  exports: [
    SemesterplannermodulFormDialogComponent
  ],
})
export class SemesterplannermodulModule { }
