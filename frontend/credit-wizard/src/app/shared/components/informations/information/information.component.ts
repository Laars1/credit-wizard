import { Component, Input, OnInit } from '@angular/core';

/**
 * Component to display a information message
 */
@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})
export class InformationComponent implements OnInit {
  @Input() title = ""
  @Input() message = ""
  constructor() { }

  ngOnInit() {
  }

}
