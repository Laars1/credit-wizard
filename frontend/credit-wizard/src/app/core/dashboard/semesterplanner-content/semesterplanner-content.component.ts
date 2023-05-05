import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { ISemesterPlannerModulDto } from 'src/app/shared/dtos/semesterPlannerModulDto';
import { ModulDetailDialogComponent } from '../../modul/modul-detail-dialog/modul-detail-dialog.component';
import { SemesterplannerDeleteDialogComponent } from '../../semesterplanner/semesterplanner-delete-dialog/semesterplanner-delete-dialog.component';
import { SemesterPlannerFormDialogComponent } from '../../semesterplanner/semesterplanner-form-dialog/semesterplanner-form-dialog.component';
import { SemesterplannermodulFormDialogComponent } from '../../semesterplannermodul/semesterplannermodul-form-dialog/semesterplannermodul-form-dialog.component';
import { FormType } from 'src/app/shared/enums/formType.enum';

/**
 * This component is responsible for displaying and managing the content of a single semester planner item.
 * It receives the semester planner item and the degree id as inputs.
 * It calculates and displays the total and current ETCS points for the semester planner item.
 * It provides methods for opening various dialogs for adding, editing, and deleting module items associated with the semester planner item.
 */
@Component({
  selector: 'app-semesterplanner-content',
  templateUrl: './semesterplanner-content.component.html',
  styleUrls: ['./semesterplanner-content.component.css'],
})
export class SemesterplannerContentComponent implements OnInit {
  @Input() item = {} as ISemesterPlannnerDto;
  @Input() degreeId = {} as Guid;

  totalEtcsPoints = 0;
  currentEtcsPoints = 0;
  panelOpenState = false;
  displayedColumns: string[] = [
    'modulDto.name',
    'modulDto.abbreviation',
    'grade',
  ];
  constructor(private dialogService: MatDialog) {}

  ngOnInit() {
    console.log(this.item);
    this.totalEtcsPoints = this.getTotalEtcs() ?? 0;
    this.currentEtcsPoints = this.getCurrentEtcs() ?? 0;
  }

  /**
   * Calculates the total ETCS points for the semester planner item by summing the ETCS points of each module item associated with the item.
   * @returns {number} The total ETCS points for the semester planner item.
   */
  getTotalEtcs() {
    if (this.item.semesterPlannerModulDtos == null) return 0;
    return this.item.semesterPlannerModulDtos
      .map((x) => {
        return x.modulDto?.etcsPoints ?? 0;
      })
      .reduce((x, y) => x + Number(y), 0);
  }

  /**
   * Calculates the current ETCS points for the semester planner item by summing the ETCS points of each module item associated with the item that has a grade of 4 or higher.
   * @returns {number} The current ETCS points for the semester planner item.
   */
  getCurrentEtcs() {
    if (this.item.semesterPlannerModulDtos == null) return 0;
    return this.item.semesterPlannerModulDtos
      .map((x) => {
        return x.grade != null && x.grade >= 4
          ? x.modulDto?.etcsPoints ?? 0
          : 0;
      })
      .reduce((x, y) => x + Number(y), 0);
  }

  /**
   * Determines if the module item is required for the degree associated with the semester planner item.
   * @param dto - The module planner module item dto to check.
   * @returns True if the module item is required for the degree, false otherwise.
   */
  isModulRequiredForDegree(dto: ISemesterPlannerModulDto) {
    let entry = dto.modulDto?.degreeModulDtos.find(
      (x) => x.degreeId == this.degreeId
    );
    return entry!.isRequired;
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
   * Open a form diaglog to edit the semesterplanner entry
   */
  openEditFormDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = this.item;

    this.dialogService.open(SemesterPlannerFormDialogComponent, dialogConfig);
  }

  /**
   * Open a form diaglog to delete the semesterplanner entry
   */
  openDeleteDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = this.item;

    this.dialogService.open(SemesterplannerDeleteDialogComponent, dialogConfig);
  }

  /**
   * Open a form diaglog to add a modul to the semesterplanner entry
   */
  openModulCreateFormDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      semesterPlannerId: this.item.id,
      semesterTimeSlotId: this.item.semesterTimeSlotId,
      formType: FormType.Create,
    };

    this.dialogService.open(
      SemesterplannermodulFormDialogComponent,
      dialogConfig
    );
  }

  /**
   * Open a form diaglog to edit a modul to the semesterplanner entry
   * @param data SemesterPlannerModul which should be edited
   */
  openModulEditFormDialog(data: ISemesterPlannerModulDto) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      semesterPlannerId: this.item.id,
      semesterTimeSlotId: this.item.semesterTimeSlotId,
      item: data,
      formType: FormType.Edit,
    };

    this.dialogService.open(
      SemesterplannermodulFormDialogComponent,
      dialogConfig
    );
  }

    /**
   * Open a form diaglog to deleted a modul to the semesterplanner entry
   * @param data SemesterPlannerModul which should be deleted
   */
  openModulDeleteFormDialog(data: ISemesterPlannerModulDto) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      semesterPlannerId: this.item.id,
      semesterTimeSlotId: this.item.semesterTimeSlotId,
      item: data,
      formType: FormType.Delete,
    };

    this.dialogService.open(
      SemesterplannermodulFormDialogComponent,
      dialogConfig
    );
  }
}
