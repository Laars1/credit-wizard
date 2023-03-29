import { Component, OnInit } from '@angular/core';
import { ISemesterDto } from 'src/app/shared/dtos/semesterDto';
import { SemesterService } from 'src/app/shared/services/api/semester.service';

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
