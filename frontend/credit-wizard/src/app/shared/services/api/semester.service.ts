import { ISemesterDto } from '../../dtos/semesterDto';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, Observable } from 'rxjs';
import { ApiService } from 'src/app/shared/services/api/base/api.service';
import { Guid } from 'guid-typescript';

/**
 * API Service for handling semester requests
 */
@Injectable({
  providedIn: 'root',
})
export class SemesterService {
  private readonly apiUrl = 'semester';
  constructor(private apiService: ApiService) {}

  /**
   * Get all possible semester from the API
   * @returns {Observable<ISemesterDto[]>} Observable with all semesters as array
   */
  public get(): Observable<ISemesterDto[]> {
    return this.apiService.get<ISemesterDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}
