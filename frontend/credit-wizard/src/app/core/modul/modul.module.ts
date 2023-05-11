import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material.module';
import { ModulDetailDialogComponent } from './modul-detail-dialog/modul-detail-dialog.component';
import { ModulListComponent } from './modul-list/modul-list-component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
  ],
  declarations: [
    ModulDetailDialogComponent,
    ModulListComponent
  ],
  exports: [
    ModulDetailDialogComponent,
    ModulListComponent
  ],
})
export class ModulModule { }
