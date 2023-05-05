import { Guid } from 'guid-typescript';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IModulDto } from 'src/app/shared/dtos/modulDto';
import { ModulService } from 'src/app/shared/services/api/modul.service';

/**
 * Dialog Component to show iformation for a specific modul
 */
@Component({
  selector: 'app-modul-dialog',
  templateUrl: './modul-detail-dialog.component.html',
})
export class ModulDetailDialogComponent implements OnInit {
  item = {} as IModulDto;
  loaded = false;
  constructor(
    private modulService: ModulService,
    private dialogRef: MatDialogRef<ModulDetailDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { modulId: Guid })
    {}

  ngOnInit() {
    this.dialogRef.updateSize("30%")
    this.modulService.getById(this.data.modulId).subscribe((x: IModulDto) => {
      this.item = x;
      this.loaded = true;
    });
  }

  /**
   * Closes the diaglog
   */
  close() {
    this.dialogRef.close();
  }
}
