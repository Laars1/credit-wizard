import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DangerComponent } from './danger/danger.component';
import { WarningComponent } from './warning/warning.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    DangerComponent,
    WarningComponent
  ],
  exports: [
    DangerComponent,
    WarningComponent
  ],
})
export class InformationsModule { }
