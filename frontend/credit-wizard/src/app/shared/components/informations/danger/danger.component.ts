import { Component, Input, OnInit } from '@angular/core';

/**
 * Component to display a danger (error) message
 */
@Component({
  selector: 'app-danger',
  templateUrl: './danger.component.html',
  styleUrls: ['./danger.component.css']
})
export class DangerComponent implements OnInit {
  @Input() title = ""
  @Input() message = ""
  constructor() { }

  ngOnInit() {
  }

}
