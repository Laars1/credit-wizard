import { Component, Input, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';

@Component({
  selector: 'app-dashboard-progress-bar',
  templateUrl: './dashboard-progress-bar.component.html',
  styleUrls: ['./dashboard-progress-bar.component.css']
})
export class DashboardProgressBarComponent implements OnInit {

  @Input() title = "";
  @Input() description = "";
  @Input() value = 0;
  color: ThemePalette = "accent"
  
  constructor() { }

  ngOnInit() {
  }

}
