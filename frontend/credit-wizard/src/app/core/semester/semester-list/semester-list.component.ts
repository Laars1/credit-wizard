import { Component, OnInit } from '@angular/core';
import { ISemesterDto } from 'src/app/shared/dtos/semesterDto';
import { SemesterService } from 'src/app/shared/services/api/semester.service';

/**
 * Component that displays a list of semesters
 * Fetches semesters using SemesterService and displays them in a table with ID and semester number columns
 */
@Component({
  selector: 'app-semester-list',
  templateUrl: './semester-list.component.html',
  styleUrls: ['./semester-list.component.css'],
})
export class SemesterListComponent implements OnInit {
  semesters: ISemesterDto[] = [];
  displayedColumns: string[] = ['id', 'number'];

  constructor(private semesterService: SemesterService) {}

  /**
   * Fetch semesters to display them
   */
  ngOnInit(): void {
    this.semesterService.get().subscribe((s: any) => {
      this.semesters = s;
    });
  }
}
