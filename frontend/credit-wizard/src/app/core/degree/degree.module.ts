import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material.module';
import { DegreeListComponent } from './degree-list/degree-list-component';
import { DegreeDetailDialogComponent } from './degree-detail-dialog/degree-detail-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
  ],
  declarations: [
    DegreeListComponent,
    DegreeDetailDialogComponent
  ],
  exports: [
    DegreeListComponent,
    DegreeDetailDialogComponent
  ],
})
export class DegreeModule { }
