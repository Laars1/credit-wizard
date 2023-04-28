import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DangerComponent } from './danger/danger.component';
import { WarningComponent } from './warning/warning.component';
import { InformationComponent } from './information/information.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    DangerComponent,
    WarningComponent,
    InformationComponent
  ],
  exports: [
    DangerComponent,
    WarningComponent,
    InformationComponent
  ],
})
export class InformationsModule { }
