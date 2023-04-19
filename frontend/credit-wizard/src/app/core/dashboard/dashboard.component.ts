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
  user = {} as IUserDto;
  spinnerVisible = false;
  userInformationLoaded = false;
  userProgressLoaded = false;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.spinnerVisible = true
    this.userService.getCurrentUser().subscribe((u: IUserDto) => {
      this.user = u;
    })
    this.userInformationLoaded = true;
    this.checkSpinner()
  }

  setLoadedDegreeProgress(loaded: boolean){
    this.userProgressLoaded = loaded;
    this.checkSpinner()
  }

  checkSpinner() {
      this.spinnerVisible = this.userInformationLoaded && this.userProgressLoaded ? false : true;
  }

}


