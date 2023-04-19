import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';
import { SemesterplannerService } from 'src/app/shared/services/api/semesterplanner.service';

@Component({
  selector: 'app-semesterplanner-overview',
  templateUrl: './semesterplanner-overview.component.html',
  styleUrls: ['./semesterplanner-overview.component.css']
})
export class SemesterplannerOverviewComponent implements OnInit {
  @Output() loaded = new EventEmitter<boolean>();
  data = [] as ISemesterPlannnerDto[]

  constructor(private semesterplannerService: SemesterplannerService) { }

  ngOnInit() {
    this.semesterplannerService.get().subscribe((x: ISemesterPlannnerDto[]) => {
      this.data = x;
      this.loaded.emit(true);
    })
  }

}
