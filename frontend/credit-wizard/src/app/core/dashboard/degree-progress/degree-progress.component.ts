import { Component, Input, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-degree-progress',
  templateUrl: './degree-progress.component.html',
  styleUrls: ['./degree-progress.component.css']
})
export class DegreeProgressComponent implements OnInit {

  @Input() userId = {} as Guid
  totalEtcsPoints = 180;
  constructor() { }

  ngOnInit() {
  }

}
