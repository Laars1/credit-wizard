import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { IUserDto } from 'src/app/shared/dtos/userDto';
import { DegreeDetailDialogComponent } from '../../degree/degree-detail-dialog/degree-detail-dialog.component';

@Component({
  selector: 'app-user-information',
  templateUrl: './user-information.component.html',
  styleUrls: ['./user-information.component.css']
})
export class UserInformationComponent implements OnInit {

  @Input() item = {} as IUserDto
  constructor(private dialogService: MatDialog) { }

  ngOnInit() {
  }

    /**
   * This method opens a dialog to display information about the degree.
   */
    openDegreeInformationDialog() {
      const dialogConfig = new MatDialogConfig();
  
      this.dialogService.open(DegreeDetailDialogComponent, dialogConfig);
    }

}
