import { Component, OnInit } from '@angular/core';
import { IUserDto } from 'src/app/shared/dtos/userDto';
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
    });
    this.userInformationLoaded = true;
  }

  /**
   * Sets the loaded state for the degree progress.
   * @param loaded A boolean value indicating whether the degree progress is loaded or not.
   */
  setLoadedDegreeProgress(loaded: boolean) {
    this.userProgressLoaded = loaded;
    this.checkSpinner();
  }

  /**
   * Sets the loaded state for the semester planner.
   * @param loaded A boolean value indicating whether the semester planner is loaded or not.
   */
  setLoadedSemesterPlanner(loaded: boolean) {
    this.semesterPlannerInformationLoaded = loaded;
    this.checkSpinner();
  }

  /**
   * Checks the spinner visibility based on the loaded states.
   * If all information (user information, degree progress, and semester planner) is loaded, the spinner is hidden.
   * Otherwise, the spinner is shown.
   */
  checkSpinner() {
    if (this.userInformationLoaded && this.userProgressLoaded && this.semesterPlannerInformationLoaded) {
      this.spinnerVisible = false;
    } else {
      this.spinnerVisible = true;
    }
  }
}
