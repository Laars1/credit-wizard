import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IDegreeProgressDto } from 'src/app/shared/dtos/degreeProgressDto';
import { UserService } from 'src/app/shared/services/api/user.service';

@Component({
  selector: 'app-degree-progress',
  templateUrl: './degree-progress.component.html',
  styleUrls: ['./degree-progress.component.css']
})
export class DegreeProgressComponent implements OnInit {

  @Output() loaded = new EventEmitter<boolean>();
  data = {} as IDegreeProgressDto;
  descriptionProgressDegree = "";

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getCurrentUserDegreeProgress().subscribe((d: IDegreeProgressDto) => {
      this.data = d;
      this.descriptionProgressDegree = "Prozentsatz wie weit du bereits bist im Studium - Verhältnis erreichte + offene ECTs Punkte zu Total erforderlichen ETCs Punkten ("+this.data.totalDegreeEtcsPoints+")";
    });
    this.loaded.emit(true)
  }

  getProgress(){
    return Math.round(100/this.data.totalDegreeEtcsPoints*(this.data.reachedEtcsPoints + this.data.openEtcsPoints))
  }
}
