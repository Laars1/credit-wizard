import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { SemesterplannerService } from 'src/app/shared/services/api/semesterplanner.service';
import { MessageService } from 'src/app/shared/services/common/message.service';

/**
 * Component to display a confirmation dialog for deleting a semester planner
 */
@Component({
  selector: 'app-semesterplanner-delete-dialog',
  templateUrl: './semesterplanner-delete-dialog.component.html',
  styleUrls: ['./semesterplanner-delete-dialog.component.css'],
})
export class SemesterplannerDeleteDialogComponent implements OnInit {
  accept = false;

  constructor(
    private dialogRef: MatDialogRef<SemesterplannerDeleteDialogComponent>,
    private semesterPlannerService: SemesterplannerService,
    private messageService: MessageService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: ISemesterPlannnerDto
  ) {}

  ngOnInit() {
  }

  /**
   * Check if the deletion has been accepted
   * @param accepted value
   */
  checkAccept(accepted: boolean) {
    this.accept = accepted;
  }

  /**
   * Delete the selected semester planner and display a success message
   */
  delete() {
    this.semesterPlannerService.delete(this.data.id).subscribe((x: number) => {
      this.messageService.success(
        'Ihr geplantes Semester wurde gelöscht. Insgesamt wurden ' +
          x +
          ' Elemente glöscht',
        'Löschen erfolgreich'
      );
      this.router
        .navigateByUrl('/', { skipLocationChange: true })
        .then(() => this.router.navigate(['']));
      this.close();
    });
  }

  /**
   * Close the dialog
   */
  close() {
    this.dialogRef.close();
  }
}
