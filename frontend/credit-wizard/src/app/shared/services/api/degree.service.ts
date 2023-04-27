import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { IDegreeDto } from '../../dtos/degreeDto';
import { EMPTY, Observable, catchError } from 'rxjs';
import { Guid } from 'guid-typescript';
import { IDegreeModulDto } from '../../dtos/degreeModulDto';

@Injectable({
  providedIn: 'root'
})
export class DegreeService {
  private readonly apiUrl = 'degree';
  constructor(private apiService: ApiService) {}

  public getWithModules(): Observable<IDegreeDto> {
    return this.apiService.get<IDegreeDto>(this.apiUrl+"/user/current/degreemodules").pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  public getWithModulesBySemesterTimeSlotid(id: Guid): Observable<IDegreeModulDto[]> {
    return this.apiService.get<IDegreeModulDto[]>(this.apiUrl+"/user/current/degreemodules/timeslot/"+id).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}
