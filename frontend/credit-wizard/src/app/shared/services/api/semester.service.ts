import { ISemesterDto } from '../../dtos/semesterDto';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, Observable } from 'rxjs';
import { ApiService } from 'src/app/shared/services/api/base/api.service';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class SemesterService {
  private readonly apiUrl = 'semester';
  constructor(private apiService: ApiService) {}

  public get(): Observable<ISemesterDto[]> {
    return this.apiService.get<ISemesterDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  public getBySemesterId(semesterId: Guid): Observable<ISemesterDto> {
    return this.apiService
      .get<ISemesterDto>(this.apiUrl + '/semesterId' + semesterId)
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        })
      );
  }

  public getBySemesterNumber(semesterNumber: Number): Observable<ISemesterDto> {
    return this.apiService
      .get<ISemesterDto>(this.apiUrl + '/semesterNumber' + semesterNumber)
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        })
      );
  }
}
