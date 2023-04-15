import { Component, OnInit } from '@angular/core';
import { isNumber } from '@ng-bootstrap/ng-bootstrap/util/util';
import { IUserDto } from 'src/app/shared/dtos/userDto';
import { ApiService } from 'src/app/shared/services/api/base/api.service';
import { UserService } from 'src/app/shared/services/api/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  user: IUserDto | undefined;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getCurrentUser().subscribe((u: IUserDto) => {
      console.log(u)
      this.user = u;
    })
  }

}
