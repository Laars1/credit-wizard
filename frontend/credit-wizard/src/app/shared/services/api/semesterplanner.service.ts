import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { EMPTY, Observable, catchError } from 'rxjs';
import { ISemesterPlannnerDto } from '../../dtos/semesterPlannerDto';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
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

  public create(data: ISemesterPlannnerDto) {
    return this.apiService.post<number>(this.apiUrl, data).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  public edit(id: Guid, data: ISemesterPlannnerDto) {
    return this.apiService.put<number>(this.apiUrl + '/' + id, data).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  public delete(id: Guid): Observable<number> {
    return this.apiService.delete<number>(this.apiUrl + '/' + id).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}
