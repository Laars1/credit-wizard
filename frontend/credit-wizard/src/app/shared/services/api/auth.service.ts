import { ILoginDto } from './../../dtos/loginDto';
import { Injectable, Type } from '@angular/core';
import { ApiService } from './base/api.service';
import { LocalStorageService } from '../common/local-storage.service';
import { ITokenDto } from '../../dtos/tokenDto';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = 'authentication';
  constructor(
    private apiService: ApiService,
    private localStorageService: LocalStorageService,
    public router: Router
  ) {}

  signIn(user: ILoginDto) {
    return this.apiService
      .post<ITokenDto, ILoginDto>(this.apiUrl + '/login', user)
      .subscribe((res: any) => {
        this.localStorageService.set('access_token', res.token);
        this.router.navigate(['dashboard']);
      });
  }

  logout() {
    let removeToken = localStorage.removeItem('access_token');
    if (removeToken == null) {
      this.router.navigate(['login']);
    }
  }

  getToken() {
    return localStorage.getItem('access_token');
  }

  get isLoggedIn(): boolean {
    let authToken = this.localStorageService.get('access_token');
    return authToken !== null ? true : false;
  }
}
