import { SemesterService } from '../../../shared/services/api/semester.service';
import { ISemesterDto } from './../../../shared/dtos/semesterDto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-semester-list',
  templateUrl: './semester-list.component.html',
  styleUrls: ['./semester-list.component.css']
})
export class SemesterListComponent implements OnInit {
  semesters: ISemesterDto[] = []
  displayedColumns: string[] = ['id', 'number'];

  constructor(private semesterService: SemesterService) { }

  ngOnInit(): void {
    this.semesterService.get().subscribe((s: any) => {
      this.semesters = s;
    })

   }

}
