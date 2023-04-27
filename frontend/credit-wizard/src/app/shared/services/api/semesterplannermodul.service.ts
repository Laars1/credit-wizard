import { Injectable } from '@angular/core';
import { ApiService } from './base/api.service';
import { EMPTY, Observable, catchError } from 'rxjs';
import { Guid } from 'guid-typescript';
import { ISemesterPlannerModulDto } from '../../dtos/semesterPlannerModulDto';
@Injectable({
  providedIn: 'root'
})
export class SemesterplannermodulService {
  private readonly apiUrl = 'semesterplannermodul';
  constructor(private apiService: ApiService) {}

public create(data: ISemesterPlannerModulDto) {
  return this.apiService.post<number>(this.apiUrl, data).pipe(
    catchError((err) => {
      console.error(err);
      return EMPTY;
    })
  );
}

public edit(semesterPlannerId: Guid, modulId: Guid, data: ISemesterPlannerModulDto) {
  return this.apiService.put<number>(this.apiUrl + '/semesterplannerId=' + semesterPlannerId+"&modulid="+modulId, data).pipe(
    catchError((err) => {
      console.error(err);
      return EMPTY;
    })
  );
}

public delete(semesterPlannerId: Guid, modulId: Guid): Observable<number> {
  return this.apiService.delete<number>(this.apiUrl + '/semesterplannerId=' + semesterPlannerId+"&modulid="+modulId).pipe(
    catchError((err) => {
      console.error(err);
      return EMPTY;
    })
  );
}

}
