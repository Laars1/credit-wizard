import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { EMPTY, Observable, catchError } from 'rxjs';
import { ISemesterPlannnerDto } from '../../dtos/semesterPlannerDto';

@Injectable({
  providedIn: 'root'
})
export class SemesterplannerService {

private readonly apiUrl = 'semesterplanner';
constructor(private apiService: ApiService) {}

public get(): Observable<ISemesterPlannnerDto[]> {
  return this.apiService.get<ISemesterPlannnerDto[]>(this.apiUrl).pipe(
    catchError((err) => {
      console.error(err);
      return EMPTY;
    })
  );
}
}
