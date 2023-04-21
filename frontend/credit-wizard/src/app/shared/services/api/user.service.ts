import { ISemesterDto } from '../../dtos/semesterDto';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, map, Observable } from 'rxjs';
import { ApiService } from 'src/app/shared/services/api/base/api.service';
import { Guid } from 'guid-typescript';
import { IUserDto } from '../../dtos/userDto';
import { IDegreeProgressDto } from '../../dtos/degreeProgressDto';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly apiUrl = 'user';
  constructor(private apiService: ApiService) {}

  public getCurrentUser(): Observable<IUserDto> {
    return this.apiService.get<IUserDto>(this.apiUrl + "/current").pipe(
      map((x: IUserDto) => x as IUserDto),
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }

  public getCurrentUserDegreeProgress(): Observable<IDegreeProgressDto> {
    return this.apiService.get<IDegreeProgressDto>(this.apiUrl + "/current/degreeprogress").pipe(
      map((x: IDegreeProgressDto) => x as IDegreeProgressDto),
      catchError((err) => {
        console.error(err);
        return EMPTY;
      })
    );
  }
}