import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { EMPTY, Observable, catchError } from 'rxjs';
import { ISemesterPlannnerDto } from '../../dtos/semesterPlannerDto';
import { Guid } from 'guid-typescript';

/**
 * API Service for handling semesterplanner requests
 */
@Injectable({
  providedIn: 'root',
})
export class SemesterplannerService {
  private readonly apiUrl = 'semesterplanner';
  constructor(private apiService: ApiService) {}

  /**
   * Get all planned semester for logged in user
   * @returns Observable of all planned semester as array
   */
  public get(): Observable<ISemesterPlannnerDto[]> {
    return this.apiService.get<ISemesterPlannnerDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  /**
   * Send a new planned semester for the logged in user
   * @param data which should be added to the database
   * @returns {number} a number of the amount of the created items
   */
  public create(data: ISemesterPlannnerDto) {
    return this.apiService.post<number>(this.apiUrl, data).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  /**
   * edit planned semester for the logged in user
   * @param id of the planned semester which should be edited
   * @param data which should be edited to the database
   * @returns {number} a number of the amount of the edited items
   */
  public edit(id: Guid, data: ISemesterPlannnerDto) {
    return this.apiService.put<number>(this.apiUrl + '/' + id, data).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  /**
   * Delete a planned semester for the logged in user
   * @param id of the item which should be deleted
   * @returns {number} a number of the amount of the deleted items
   */
  public delete(id: Guid): Observable<number> {
    return this.apiService.delete<number>(this.apiUrl + '/' + id).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}
