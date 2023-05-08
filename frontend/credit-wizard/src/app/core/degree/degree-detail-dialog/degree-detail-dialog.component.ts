import { Component, Inject, OnInit } from '@angular/core';
import { IDegreeDto } from 'src/app/shared/dtos/degreeDto';
import { DegreeService } from 'src/app/shared/services/api/degree.service';
import { ModulDetailDialogComponent } from '../../modul/modul-detail-dialog/modul-detail-dialog.component';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { SemesterplannermodulService } from 'src/app/shared/services/api/semesterplannermodul.service';
import { Guid } from 'guid-typescript';

/**
 * Dialog component for all details of a degree. Degree is shown which is referenced to current user
 */
@Component({
  selector: 'app-degree-detail-dialog',
  templateUrl: './degree-detail-dialog.component.html',
  styleUrls: ['./degree-detail-dialog.component.css']
})
export class DegreeDetailDialogComponent implements OnInit {

  item = {} as IDegreeDto;
  completedModules = [] as Guid[];
  loaded = false;
  constructor(
    private degreeService: DegreeService,
    private semesterPlannerModulService: SemesterplannermodulService,
    private dialogService: MatDialog,
    private dialogRef: MatDialogRef<DegreeDetailDialogComponent>)
    {}

  ngOnInit() {
    this.degreeService.getWithModules().subscribe((x: IDegreeDto) => {
      this.item = x;
      this.item.degreeModulDtos = this.item.degreeModulDtos.sort((a, b) => Number(b.isRequired) - Number(a.isRequired)) // Order by isRequired
    });

    this.semesterPlannerModulService.getCompletedByUser().subscribe((x: Guid[]) => {
      this.completedModules = x;
      this.loaded = true;
    });
  }

    /**
   * This method opens a dialog to display information about a modul.
   * @param modulId specifies the module to display
   */
    openModulInformationDialog(modulId: Guid) {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data = { modulId: modulId };
  
      this.dialogService.open(ModulDetailDialogComponent, dialogConfig);
    }

  /**
   * Closes the diaglog
   */
  close() {
    this.dialogRef.close();
  }
}
