import { IModulDto } from '../../dtos/modulDto';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, Observable } from 'rxjs';
import { ApiService } from 'src/app/shared/services/api/base/api.service';

@Injectable({
  providedIn: 'root',
})
export class ModulService {
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

}
