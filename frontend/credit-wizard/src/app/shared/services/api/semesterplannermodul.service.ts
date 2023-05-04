import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { EMPTY, Observable, catchError } from 'rxjs';
import { Guid } from 'guid-typescript';
import { ISemesterPlannerModulDto } from '../../dtos/semesterPlannerModulDto';

/**
 * API Service for handling semesterplannermodul requests
 */
@Injectable({
  providedIn: 'root',
})
export class SemesterplannermodulService {
  private readonly apiUrl = 'semesterplannermodul';
  constructor(private apiService: ApiService) {}

  /**
   * Get a list of all completed modules by the logged in user
   * @returns array of the ids of the completed modules as observable
   */
  public getCompletedByUser(): Observable<Guid[]> {
    return this.apiService
      .get<Guid[]>(this.apiUrl + '/user/current/completed')
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        })
      );
  }

  /**
   * create semesterplannermodul for the logged in user
   * @param data which should be added to the database
   * @returns a number of the amount of the created items
   */
  public create(data: ISemesterPlannerModulDto) {
    return this.apiService.post<number>(this.apiUrl, data).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  /**
   * edit semesterplannermodul for the logged in user
   * @param semesterPlannerId to indicate where the semesterplannermodul belongs to
   * @param modulId referenced modul of the semesterplannermodul
   * @param data which should be edited
   * @returns a number of the amount of the edited items
   */
  public edit(
    semesterPlannerId: Guid,
    modulId: Guid,
    data: ISemesterPlannerModulDto
  ) {
    return this.apiService
      .put<number>(
        this.apiUrl +
          '/semesterplannerId=' +
          semesterPlannerId +
          '&modulid=' +
          modulId,
        data
      )
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        })
      );
  }

  /**
   * delete semesterplannermodul for the logged in user
   * @param semesterPlannerId to indicate where the semesterplannermodul belongs to
   * @param modulId referenced modul of the semesterplannermodul
   * @returns a number of the amount of the deleted items
   */
  public delete(semesterPlannerId: Guid, modulId: Guid): Observable<number> {
    return this.apiService
      .delete<number>(
        this.apiUrl +
          '/semesterplannerId=' +
          semesterPlannerId +
          '&modulid=' +
          modulId
      )
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        })
      );
  }
}
