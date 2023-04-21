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
  spinnerVisible = true;
  userInformationLoaded = false;
  semesterPlannerInformationLoaded = false;
  userProgressLoaded = false;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getCurrentUser().subscribe((u: IUserDto) => {
      this.user = u;
    })
    this.userInformationLoaded = true;
  }

  setLoadedDegreeProgress(loaded: boolean){
    this.userProgressLoaded = loaded;
    this.checkSpinner();
  }

  setLoadedSemesterPlanner(loaded: boolean){
    this.semesterPlannerInformationLoaded = loaded;
    this.checkSpinner();
  }

  checkSpinner() {
    if(this.userInformationLoaded && this.userProgressLoaded && this.semesterPlannerInformationLoaded){
      this.spinnerVisible = false;
    }
    else{
      this.spinnerVisible = true;
    }
  }

}


