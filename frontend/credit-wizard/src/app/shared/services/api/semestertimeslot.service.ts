import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { ISemesterTimeSlotDto } from '../../dtos/semesterTimeSlotDto';
import { Observable, catchError, EMPTY } from 'rxjs';

/**
 * API Service for handling SemesterTimeSlot requests
 */
@Injectable({
  providedIn: 'root'
})
export class SemestertimeslotService {
  private readonly apiUrl = 'semestertimeslot';
  constructor(private apiService: ApiService) {}

  /**
   * Get all semestertimeslots from the API
   * @returns a array of all semestertimeslot as observable
   */
  public get(): Observable<ISemesterTimeSlotDto[]> {
    return this.apiService.get<ISemesterTimeSlotDto[]>(this.apiUrl);
  }
}
