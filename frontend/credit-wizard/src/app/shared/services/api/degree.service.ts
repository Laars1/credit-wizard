import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/shared/services/api/base/api.service';
import { IDegreeDto } from '../../dtos/degreeDto';
import { EMPTY, Observable, catchError } from 'rxjs';
import { Guid } from 'guid-typescript';
import { IDegreeModulDto } from '../../dtos/degreeModulDto';

/**
 * API Service for handling degree requests
 */
@Injectable({
  providedIn: 'root',
})
export class DegreeService {
  private readonly apiUrl = 'degree';
  constructor(private apiService: ApiService) {}

  /**
   * Get all degrees from the API
   * @returns {Observable<IDegreeDto[]>} an Observable with the degrees
   */
  public get(): Observable<IDegreeDto[]> {
    return this.apiService.get<IDegreeDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  /**
   * Get all degrees with their included modules from the API
   * @returns {Observable<IDegreeDto>} an Observable with the degrees
   */
  public getWithModules(): Observable<IDegreeDto> {
    return this.apiService
      .get<IDegreeDto>(this.apiUrl + '/user/current/degreemodules')
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        })
      );
  }

  /**
   * Get all modules from one degree by their semestertimeslot id
   * @param id id of the selected semestertimeslot
   * @returns {Observable<IDegreeDto[]>} Observable with the degrees with alle modules from degree
   */
  public getWithModulesBySemesterTimeSlotid(
    id: Guid
  ): Observable<IDegreeModulDto[]> {
    return this.apiService
      .get<IDegreeModulDto[]>(
        this.apiUrl + '/user/current/degreemodules/timeslot/' + id
      )
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        })
      );
  }
}
