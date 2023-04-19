import { Component, Input, OnInit } from '@angular/core';
import { ISemesterPlannnerDto } from 'src/app/shared/dtos/semesterPlannerDto';

@Component({
  selector: 'app-semesterplanner-content',
  templateUrl: './semesterplanner-content.component.html',
  styleUrls: ['./semesterplanner-content.component.css']
})
export class SemesterplannerContentComponent implements OnInit {
  @Input() item = {} as ISemesterPlannnerDto
  totalEtcsPoints = 0;
  currentEtcsPoints = 0;
  panelOpenState = false;
  displayedColumns: string[] = ['modulDto.name', 'modulDto.abbreviation', 'grade'];
  constructor() { }

  ngOnInit() {
    this.totalEtcsPoints = this.getTotalEtcs();
    this.currentEtcsPoints = this.getCurrentEtcs()
    
  }

  getTotalEtcs(){
    return this.item.semesterPlannerModulDtos.map(x =>{return x.modulDto.etcsPoints}).reduce((x, y) => x + Number(y), 0)
  }

  getCurrentEtcs(){
    return this.item.semesterPlannerModulDtos.map(x => {return x.grade >= 4 ? x.modulDto.etcsPoints : 0}).reduce((x, y) => x + Number(y), 0)
  }

}
