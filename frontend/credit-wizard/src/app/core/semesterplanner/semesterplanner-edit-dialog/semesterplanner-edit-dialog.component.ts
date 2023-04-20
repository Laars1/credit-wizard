import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormControl, 
  FormGroup,
  FormBuilder,
  FormArray,
  Validators } from '@angular/forms';

@Component({
  selector: 'app-semesterplanner-edit-dialog',
  templateUrl: './semesterplanner-edit-dialog.component.html',
  styleUrls: ['./semesterplanner-edit-dialog.component.css']
})
export class SemesterplannerEditDialogComponent implements OnInit {
  test = [
    {name: "Test", grade: 4},
    {name: "Test2", grade: 5},
    {name: "Test3", grade: 6}]
  form = this.fb.group({
    semester: [{ value: '', disabled: true }, Validators.required],
    completed: [{ value: false, disabled: false }, Validators.required],
    moduls: [this.test.forEach(x => this.createModulForm())]
  });

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<SemesterplannerEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ISemesterPlannnerDto)
    {}

  ngOnInit() {
    this.dialogRef.updateSize("500px", "500px");
    console.log(this.data)

    
    
    // this.form.patchValue({
    //   semester: "Semester "+this.data.semesterDto.number,
    //   completed: this.data.completed,
    // })
  }

  createModulForm():FormGroup{
    console.log("Created")
    return this.fb.group({
      name:[{ value: '', disabled: true }],
      grade:[null,Validators.required]
    })
  }

  save(){
    console.log("Triggered")
  }

  close() {
    this.dialogRef.close();
  }
}
