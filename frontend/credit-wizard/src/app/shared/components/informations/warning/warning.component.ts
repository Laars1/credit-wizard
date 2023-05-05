import { Component, Input, OnInit } from '@angular/core';

/**
 * Component to display a warning message
 */
@Component({
  selector: 'app-warning',
  templateUrl: './warning.component.html',
  styleUrls: ['./warning.component.css']
})
export class WarningComponent implements OnInit {
  @Input() title = ""
  @Input() message = ""
  constructor() { }

  ngOnInit() {
  }

}
