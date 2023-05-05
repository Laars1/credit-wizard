import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { SemesterplannerService } from 'src/app/shared/services/api/semesterplanner.service';
import { SemesterPlannerFormDialogComponent } from '../../semesterplanner/semesterplanner-form-dialog/semesterplanner-form-dialog.component';

@Component({
  selector: 'app-semesterplanner-overview',
  templateUrl: './semesterplanner-overview.component.html',
  styleUrls: ['./semesterplanner-overview.component.css'],
})
export class SemesterplannerOverviewComponent implements OnInit {
  @Input() degreeId = {} as Guid;
  @Input() userId = {} as Guid;
  @Output() loaded = new EventEmitter<boolean>();
  data = [] as ISemesterPlannnerDto[];

  constructor(
    private semesterplannerService: SemesterplannerService,
    private dialogService: MatDialog
  ) {}

  ngOnInit() {
    this.semesterplannerService.get().subscribe((x: ISemesterPlannnerDto[]) => {
      this.data = x;
      this.loaded.emit(true);
    });
  }

  /**
   * Opens a dialog box to create a new semester planner.
   * Sets the dialog configuration with user ID data and opens the dialog.
   */
  openCreateFormDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = { userId: this.userId } as ISemesterPlannnerDto;
    this.dialogService.open(SemesterPlannerFormDialogComponent, dialogConfig);
  }
}
