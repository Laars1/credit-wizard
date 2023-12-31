import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IDegreeModulDto } from 'src/app/shared/dtos/degreeModulDto';
import { ISemesterPlannerModulDto } from 'src/app/shared/dtos/semesterPlannerModulDto';
import { DegreeService } from 'src/app/shared/services/api/degree.service';
import { MessageService } from 'src/app/shared/services/common/message.service';
import { ISelectModul } from '../../../shared/dtos/modalDtos/ISelectModul';
import { ISemesterplannermodulFormDto } from 'src/app/shared/dtos/modalDtos/semesterplannermodulFormDto';
import { SemesterplannermodulService } from 'src/app/shared/services/api/semesterplannermodul.service';
import { Guid } from 'guid-typescript';
import { FormType } from 'src/app/shared/enums/formType.enum';

/**
 * Component for a dialog that allows creating, editing, or deleting a module in a semester planner.
 */
@Component({
  selector: 'app-semesterplannermodul-form-dialog',
  templateUrl: './semesterplannermodul-form-dialog.component.html',
  styleUrls: ['./semesterplannermodul-form-dialog.component.css'],
})
export class SemesterplannermodulFormDialogComponent implements OnInit {
  action = '';
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
    this.action =
      this.data.formType == FormType.Edit
        ? 'Bearbeiten'
        : this.data.formType == FormType.Create
        ? 'Erstellen'
        : 'Löschen';
    this.title += this.action;
    this.loadData();
    this.initForm();
  }

  /**
   * Loads the data needed for the component.
   */
  loadData() {
    this.semesterPlannerModulService
      .getCompletedByUser()
      .subscribe((x: Guid[]) => {
        this.completedModules = x;
      });

    this.degreeService
      .getWithModulesBySemesterTimeSlotid(this.data.semesterTimeSlotId)
      .subscribe((x: IDegreeModulDto[]) => {
        this.selectDegreeModules = [
          {
            name: 'Für Abschluss notwendig',
            degreeModulDto: x.filter((x) => x.isRequired),
          },
          {
            name: 'Für Abschluss NICHT notwendig',
            degreeModulDto: x.filter((x) => !x.isRequired),
          },
        ];
        this.loaded = true;
      });
  }

  /**
   * Initializes the form for the dialog.
   */
  initForm() {
    this.form = this.fb.group({
      modulId: ['', Validators.required],
      grade: [Number, [Validators.min(1), Validators.max(6)]],
    });

    switch (this.data.formType) {
      case FormType.Edit:
        this.form.controls['grade'].addValidators(Validators.required);
        this.form.patchValue({
          modulId: this.data.item.modulId,
          grade: this.data.item.grade,
        });
        this.form.controls['modulId'].disable();
        break;
      case FormType.Create:
        this.form.controls['grade'].disable();
        break;
      case FormType.Delete:
        this.form.patchValue({
          modulId: this.data.item.modulId,
          grade: this.data.item.grade,
        });
        this.form.controls['grade'].disable();
        this.form.controls['modulId'].disable();
        break;
    }
  }

  /**
   * Validates the form and saves the data based on the formType.
   * if the form is valid or disabled, it saves the data and navigates to the homepage.
   * If the form is invalid, it sets the showError flag to true.
   */
  save() {
    if (this.form.valid || this.form.disabled) {
      this.showError = false;
      const data = {
        modulId: this.form.get('modulId')?.value,
        semesterPlannerId: this.data.semesterPlannerId,
        grade: this.form.get('grade')?.value,
      };

      switch (this.data.formType) {
        case FormType.Create:
          this.createItem(data);
          break;
        case FormType.Edit:
          this.editItem(data);
          break;
        case FormType.Delete:
          this.deleteItem(data);
          break;
      }
    } else {
      this.showError = true;
    }
  }

  /**
   * Calls the semesterPlannerModulService to create a new item with the given data.
   * after a successful creation, it navigates to the homepage and displays a success message.
   * @param data The data to create the item with.
   */
  createItem(data: ISemesterPlannerModulDto) {
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

  /**
   * Calls the semesterPlannerModulService to edit an existing item with the given data.
   * After a successful edit, it navigates to the homepage and displays a success message.
   * @param data The data to edit the item with.
   */
  editItem(data: ISemesterPlannerModulDto) {
    this.semesterPlannerModulService
      .edit(data.semesterPlannerId, data.modulId, data)
      .subscribe((x: number) => {
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

  /**
   * Calls the semesterPlannerModulService to delete an existing item with the given data.
   * after a successful deletion, it navigates to the homepage and displays a success message.
   * @param data The data to delete the item with.
   */
  deleteItem(data: ISemesterPlannerModulDto) {
    this.semesterPlannerModulService
      .delete(data.semesterPlannerId, data.modulId)
      .subscribe((x: number) => {
        this.messageService.success(
          'Das ausgewählte Modul wurde gelöscht. Insgesamt wurden ' +
            x +
            ' Elemente gelöscht',
          'Löschen erfolgreich'
        );
        this.router
          .navigateByUrl('/', { skipLocationChange: true })
          .then(() => this.router.navigate(['']));
        this.close();
      });
  }

  /**
   * Closes the current dialog
   */
  close() {
    this.dialogRef.close();
  }
}
