import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { ISemesterTimeSlotDto } from '../../dtos/semesterTimeSlotDto';
import { Observable, catchError, EMPTY } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SemestertimeslotService {
  private readonly apiUrl = 'semestertimeslot';
  constructor(private apiService: ApiService) {}

  public get(): Observable<ISemesterTimeSlotDto[]> {
    return this.apiService.get<ISemesterTimeSlotDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}
