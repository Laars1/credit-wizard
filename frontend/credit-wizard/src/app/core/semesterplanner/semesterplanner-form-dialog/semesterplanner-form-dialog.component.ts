import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { SemesterService } from 'src/app/shared/services/api/semester.service';
import { ISemesterDto } from 'src/app/shared/dtos/semesterDto';
import { SemestertimeslotService } from 'src/app/shared/services/api/semestertimeslot.service';
import { ISemesterTimeSlotDto } from 'src/app/shared/dtos/semesterTimeSlotDto';
import { SemesterplannerService } from 'src/app/shared/services/api/semesterplanner.service';
import { MessageService } from 'src/app/shared/services/common/message.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-semester-form-dialog',
  templateUrl: './semesterplanner-form-dialog.component.html',
  styleUrls: ['./semesterplanner-form-dialog.component.css'],
})
export class SemesterPlannerFormDialogComponent implements OnInit {
  isCreating = true;
  title = 'Semester Planung ';
  semesters: ISemesterDto[] | undefined;
  semesterTimeSlots: ISemesterTimeSlotDto[] | undefined;
  form!: FormGroup;
  showError = false;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<SemesterPlannerFormDialogComponent>,
    private semesterService: SemesterService,
    private semesterTimeSlotService: SemestertimeslotService,
    private semesterPlannerService: SemesterplannerService,
    private messageService: MessageService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: ISemesterPlannnerDto
  ) {}

  ngOnInit() {
    this.isCreating = this.data?.id == undefined;
    this.title += this.data?.id != undefined ? 'bearbeiten' : 'erstellen';
    console.log(this.data);
    this.loadData();
    this.initForm();
  }

  loadData() {
    this.semesterService.get().subscribe((x: ISemesterDto[]) => {
      this.semesters = x;
    });
    this.semesterTimeSlotService
      .get()
      .subscribe((x: ISemesterTimeSlotDto[]) => {
        this.semesterTimeSlots = x;
        console.log(x)
      });
  }

  initForm() {
    this.form = this.fb.group({
      semesterId: ['', Validators.required],
      semesterTimeSlotId: ['', Validators.required],
      completed: [false],
    });

    if (!this.isCreating) {
      this.form.controls['completed'].addValidators(Validators.required);

      this.form.patchValue({
        semesterId: this.data.semesterId,
        semesterTimeSlotId: this.data.semesterTimeSlotId,
        completed: this.data.completed,
      });
    } else {
      this.form.controls['completed'].disable();
    }
  }

  save() {
    console.log(this.form);
    if (this.form.valid) {
      this.showError = false;
      let data = {
        id: this.data.id,
        userId: this.data.userId,
        semesterId: this.form.get('semesterId')?.value,
        semesterTimeSlotId: this.form.get('semesterTimeSlotId')?.value,
        completed: this.form.get('completed')?.value,
      } as ISemesterPlannnerDto;

      if(this.isCreating){
        this.createItem(data)
      }
      else{
        this.editItem(data)
      }
    } else {
      this.showError = true;
    }
  }

  createItem(data: ISemesterPlannnerDto){
    this.semesterPlannerService.create(data).subscribe((x: number) => {
      this.messageService.success(
        'Ihr geplantes Semester wurde erstellt. Insgesamt wurden ' +
          x +
          ' Elemente hinzugefügt',
        'Erstellen erfolgreich'
      );
      this.router
        .navigateByUrl('/', { skipLocationChange: true })
        .then(() => this.router.navigate(['']));
      this.close();
    });
  }

  editItem(data: ISemesterPlannnerDto){
    this.semesterPlannerService.edit(data.id, data).subscribe((x: number) => {
      this.messageService.success(
        'Ihr geplantes Semester wurde editiert. Insgesamt wurden ' +
          x +
          ' Elemente bearbeitet',
        'Bearbeiten erfolgreich'
      );
      this.router
        .navigateByUrl('/', { skipLocationChange: true })
        .then(() => this.router.navigate(['']));
      this.close();
    });
  }

  close() {
    this.dialogRef.close();
  }
}
