import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-semesterplanner-edit-dialog',
  templateUrl: './semesterplanner-edit-dialog.component.html',
  styleUrls: ['./semesterplanner-edit-dialog.component.css']
})
export class SemesterplannerEditDialogComponent implements OnInit {
  
  constructor(
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<SemesterplannerEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ISemesterPlannnerDto)
    {}

  ngOnInit() {
    console.log(this.data)
  }

  close() {
    this.dialogRef.close();
  }
}
