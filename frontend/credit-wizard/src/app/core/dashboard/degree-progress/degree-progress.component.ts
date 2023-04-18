import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { Guid } from 'guid-typescript';
import { IDegreeProgressDto } from 'src/app/shared/dtos/degreeProgressDto';
import { UserService } from 'src/app/shared/services/api/user.service';

@Component({
  selector: 'app-degree-progress',
  templateUrl: './degree-progress.component.html',
  styleUrls: ['./degree-progress.component.css']
})
export class DegreeProgressComponent implements OnInit {

  data = {} as IDegreeProgressDto;
  color: ThemePalette = "accent"
  @Output() loaded = new EventEmitter<boolean>();
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getCurrentUserDegreeProgress().subscribe((d: IDegreeProgressDto) => {
      this.data = d;
    })
    this.loaded.emit(true)
  }

  getProgress(){
    return Math.round(100/this.data.totalDegreeEtcsPoints*(this.data.reachedEtcsPoints + this.data.openEtcsPoints))
  }
}
