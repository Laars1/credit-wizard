import { Component, OnInit } from '@angular/core';
import { IDegreeDto } from 'src/app/shared/dtos/degreeDto';
import { DegreeService} from 'src/app/shared/services/api/degree.service';

/**
 * Represents the DegreeListComponent which displays the list of degrees.
 */
@Component({
  selector: 'app-degree-list',
  templateUrl: './degree-list-component.html',
  styleUrls: ['./degree-list-component.css']
})
export class DegreeListComponent implements OnInit {
  degree: IDegreeDto[] = [];
  displayedColumns: string[] = ['id', 'name', 'description'];

  constructor(private degreeService: DegreeService) { }

  /**
   * Fetch data for the degrees from the DegreeService and populate the degree array.
   */
  ngOnInit(): void {
    this.degreeService.get().subscribe((s: any) => {
      this.degree = s;
    })
   }
}

