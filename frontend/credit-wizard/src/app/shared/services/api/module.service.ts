import { IModulDto } from '../../dtos/modulsDto';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, Observable } from 'rxjs';
import { ApiService } from 'src/app/shared/services/api/base/api.service';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class ModuleService {
  private readonly apiUrl = 'modul';
  constructor(private apiService: ApiService) {}

  public get(): Observable<IModulDto[]> {
    return this.apiService.get<IModulDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  //public getByModuleId(id: Guid): Observable<IModulDto> {
  //  return this.apiService
  //    .get<IModulDto>(this.apiUrl + '/id' + id)
  //    .pipe(
  //      catchError((err) => {
  //        console.error(err);
  //        return EMPTY;
  //      })
  //    );
  //}
//
  //public getByModuleName(Modulename: Number): Observable<IModulDto> {
  //  return this.apiService
  //    .get<IModulDto>(this.apiUrl + '/Modulename' + Modulename)
  //    .pipe(
  //      catchError((err) => {
  //        console.error(err);
  //        return EMPTY;
  //      })
  //    );
  //}
}
