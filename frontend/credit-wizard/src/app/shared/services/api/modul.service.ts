import { IModulDto } from '../../dtos/modulDto';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { catchError, EMPTY, Observable } from 'rxjs';
import { ApiService } from 'src/app/shared/services/api/base/api.service';

/**
 * API Service for handling Modul requests
 */
@Injectable({
  providedIn: 'root',
})
export class ModulService {
  private readonly apiUrl = 'modul';
  constructor(private apiService: ApiService) {}

  /**
   * Get all modules from the API
   * @returns Observable with all modules as array
   */
  public get(): Observable<IModulDto[]> {
    return this.apiService.get<IModulDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  /**
   * Get a modul by its id from the API
   * @param id of the modul which should be selected
   * @returns Observable with the returned modul
   */
  public getById(id: Guid): Observable<IModulDto> {
    return this.apiService.get<IModulDto>(this.apiUrl+"/"+id).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}
