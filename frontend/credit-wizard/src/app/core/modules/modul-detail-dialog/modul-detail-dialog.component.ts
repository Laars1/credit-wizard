import { ModuleService } from 'src/app/shared/services/api/module.service';
import { Guid } from 'guid-typescript';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IModulDto } from 'src/app/shared/dtos/modulsDto';

@Component({
  selector: 'app-modul-dialog',
  templateUrl: './modul-detail-dialog.component.html',
})
export class ModulDetailDialogComponent implements OnInit {
  item = {} as IModulDto;
  loaded = false;
  constructor(
    private moduleService: ModuleService,
    private dialogRef: MatDialogRef<ModulDetailDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { modulId: Guid })
    {}

  ngOnInit() {
    this.moduleService.getById(this.data.modulId).subscribe((x: IModulDto) => {
      this.item = x;
      this.loaded = true;
    });
  }

  close() {
    this.dialogRef.close();
  }
}
