import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { ISemesterPlannerModulDto } from 'src/app/shared/dtos/semesterPlannerModulDto';
import { ModulDialogComponent } from '../../modules/modul-dialog/modul-dialog.component';

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
    this.totalEtcsPoints = this.getTotalEtcs();
    this.currentEtcsPoints = this.getCurrentEtcs();
    console.log(this.item);
  }

  getTotalEtcs() {
    return this.item.semesterPlannerModulDtos
      .map((x) => {
        return x.modulDto.etcsPoints;
      })
      .reduce((x, y) => x + Number(y), 0);
  }

  getCurrentEtcs() {
    return this.item.semesterPlannerModulDtos
      .map((x) => {
        return x.grade >= 4 ? x.modulDto.etcsPoints : 0;
      })
      .reduce((x, y) => x + Number(y), 0);
  }

  isModulRequiredForDegree(dto: ISemesterPlannerModulDto) {
    let entry = dto.modulDto.degreeModulDtos.find(x => x.degreeId == this.degreeId);
    return entry!.isRequired;
  }

  openModulInformationModal(modulId: Guid){
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = {modulId: modulId}

    this.dialogService.open(ModulDialogComponent, dialogConfig);
  }
}
