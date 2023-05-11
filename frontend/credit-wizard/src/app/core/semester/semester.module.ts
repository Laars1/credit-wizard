import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material.module';
import { SemesterListComponent } from './semester-list/semester-list.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
  ],
  declarations: [
    SemesterListComponent
  ],
  exports: [
    SemesterListComponent
  ],
})
export class SemesterModule { }
