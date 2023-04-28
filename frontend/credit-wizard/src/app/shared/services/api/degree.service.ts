import { IDegreeDto } from 'src/app/shared/dtos/degreeDto';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, Observable } from 'rxjs';
import { ApiService } from 'src/app/shared/services/api/base/api.service';

@Injectable({
  providedIn: 'root',
})
export class DegreeService {
  private readonly apiUrl = 'degree';
  constructor(private apiService: ApiService) {}

  public get(): Observable<IDegreeDto[]> {
    return this.apiService.get<IDegreeDto[]>(this.apiUrl).pipe(
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}
