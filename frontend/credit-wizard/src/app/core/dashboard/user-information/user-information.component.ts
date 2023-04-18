import { Component, Input, OnInit } from '@angular/core';
import { IUserDto } from 'src/app/shared/dtos/userDto';

@Component({
  selector: 'app-user-information',
  templateUrl: './user-information.component.html',
})
export class UserInformationComponent implements OnInit {

  @Input() item = {} as IUserDto
  constructor() { }

  ngOnInit() {
  }

}
