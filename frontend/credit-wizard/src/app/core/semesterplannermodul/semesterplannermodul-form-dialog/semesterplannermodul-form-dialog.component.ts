import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IDegreeModulDto } from 'src/app/shared/dtos/degreeModulDto';
import { ISemesterPlannerModulDto } from 'src/app/shared/dtos/semesterPlannerModulDto';
import { DegreeService } from 'src/app/shared/services/api/degree.service';
import { MessageService } from 'src/app/shared/services/common/message.service';
import { ISelectModul } from './ISelectModul';
import { ISemesterplannermodulFormDto } from 'src/app/shared/dtos/modalDtos/semesterplannermodulFormDto';
import { SemesterplannermodulService } from 'src/app/shared/services/api/semesterplannermodul.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-semesterplannermodul-form-dialog',
  templateUrl: './semesterplannermodul-form-dialog.component.html',
  styleUrls: ['./semesterplannermodul-form-dialog.component.css']
})
export class SemesterplannermodulFormDialogComponent implements OnInit {
  isCreating = true;
  title = 'Modul in Semesterplanung ';
  selectDegreeModules: ISelectModul[] | undefined;
  completedModules: Guid[] | undefined;
  form!: FormGroup;
  showError = false;
  loaded = false;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<SemesterplannermodulFormDialogComponent>,
    private messageService: MessageService,
    private degreeService: DegreeService,
    private router: Router,
    private semesterPlannerModulService: SemesterplannermodulService,
    @Inject(MAT_DIALOG_DATA) public data: ISemesterplannermodulFormDto
  ) {}

  ngOnInit() {
    console.log(this.data)
    this.isCreating = this.data?.item?.modulId == undefined;
    this.title += this.data?.item?.modulId != undefined ? 'bearbeiten' : 'erstellen';
    this.loadData();
    this.initForm();
  }

  loadData() {
    this.semesterPlannerModulService.getCompletedByUser().subscribe((x: Guid[]) => {
        this.completedModules = x
    });

    this.degreeService.getWithModulesBySemesterTimeSlotid(this.data.semesterTimeSlotId).subscribe((x: IDegreeModulDto[]) => {
      this.selectDegreeModules = [
        {
          name: "Für Abschluss notwendig",
          degreeModulDto: x.filter(x => x.isRequired),
        },
        {
          name: "Für Abschluss NICHT notwendig",
          degreeModulDto: x.filter(x => !x.isRequired)
        }
      ]
      console.log(this.data.semesterTimeSlotId)
      console.log(this.selectDegreeModules)
      this.loaded = true;
    });
  }

  initForm() {
    this.form = this.fb.group({
      modulId: ['', Validators.required],
      grade: [Number, [Validators.min(1), Validators.max(6)]],
    });

    if (!this.isCreating) {
      this.form.controls['grade'].addValidators(Validators.required);
      this.form.patchValue({
        modulId: this.data.item.modulId,
        grade: this.data.item.grade,
      });
      this.form.controls['modulId'].disable();
    } else {
      this.form.controls['grade'].disable();
    }
  }

  save() {
    console.log(this.form);
    if (this.form.valid) {
      this.showError = false;
      let data = {
        modulId: this.form.get("modulId")?.value,
        semesterPlannerId: this.data.semesterPlannerId,
        grade: this.form.get("grade")?.value
      } as ISemesterPlannerModulDto;
      console.log(data)
      if(this.isCreating){
        this.createItem(data)
      }
      else{
        this.editItem(data)
      }
    } else {
      this.showError = true;
      console.log(this.form.errors)
    }
  }

  createItem(data: ISemesterPlannerModulDto){
    this.semesterPlannerModulService.create(data).subscribe((x: number) => {
      this.messageService.success(
        'Das ausgewählte Modul wurde hinzugefügt. Insgesamt wurden ' +
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

  editItem(data: ISemesterPlannerModulDto){
    this.semesterPlannerModulService.edit(data.semesterPlannerId, data.modulId, data).subscribe((x: number) => {
      this.messageService.success(
        'Das ausgewählte Modul wurde bearbeitet. Insgesamt wurden ' +
          x +
          ' Elemente hinzugefügt',
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
