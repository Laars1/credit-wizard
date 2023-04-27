import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { ISemesterPlannerModulDto } from 'src/app/shared/dtos/semesterPlannerModulDto';
import { ModulDetailDialogComponent } from '../../modules/modul-detail-dialog/modul-detail-dialog.component';
import { SemesterplannerDeleteDialogComponent } from '../../semesterplanner/semesterplanner-delete-dialog/semesterplanner-delete-dialog.component';
import { SemesterPlannerFormDialogComponent } from '../../semesterplanner/semesterplanner-form-dialog/semesterplanner-form-dialog.component';
import { SemesterplannermodulFormDialogComponent } from '../../semesterplannermodul/semesterplannermodul-form-dialog/semesterplannermodul-form-dialog.component';

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
    this.totalEtcsPoints = this.getTotalEtcs() ?? 0;
    this.currentEtcsPoints = this.getCurrentEtcs() ?? 0;
  }

  getTotalEtcs() {
    if(this.item.semesterPlannerModulDtos == null) return 0;
    return this.item.semesterPlannerModulDtos
      .map((x) => {
        return x.modulDto?.etcsPoints ?? 0;
      })
      .reduce((x, y) => x + Number(y), 0);
  }

  getCurrentEtcs() {
    if(this.item.semesterPlannerModulDtos == null) return 0;
    return this.item.semesterPlannerModulDtos
      .map((x) => {
        return x.grade ?? 0 >= 4 ? x.modulDto?.etcsPoints ?? 0 : 0;
      })
      .reduce((x, y) => x + Number(y), 0);
  }

  isModulRequiredForDegree(dto: ISemesterPlannerModulDto) {
    let entry = dto.modulDto?.degreeModulDtos.find(x => x.degreeId == this.degreeId);
    return entry!.isRequired;
  }

  openModulInformationDialog(modulId: Guid){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {modulId: modulId}

    this.dialogService.open(ModulDetailDialogComponent, dialogConfig);
  }

  openEditFormDialog(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = this.item;

    this.dialogService.open(SemesterPlannerFormDialogComponent, dialogConfig);
  }

  openDeleteDialog(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = this.item;

    this.dialogService.open(SemesterplannerDeleteDialogComponent, dialogConfig);
  }
  
  openModulCreateFormDialog(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {semesterPlannerId: this.item.id, semesterTimeSlotId: this.item.semesterTimeSlotId};

    this.dialogService.open(SemesterplannermodulFormDialogComponent, dialogConfig);
  }
}
