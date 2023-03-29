import { LoginDto } from './../../dtos/loginDto';
import { Injectable, Type } from '@angular/core';
import { ApiService } from './base/api.service';
import { LocalStorageService } from '../common/local-storage.service';
import { TokenDto } from '../../dtos/tokenDto';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = 'authentication';
  constructor(private apiService: ApiService, private localStorageService: LocalStorageService, public router: Router) {}

  signIn(user: LoginDto) {
    return this.apiService
      .post<TokenDto, LoginDto>(this.apiUrl + '/login', user)
      .subscribe((res: any) => {
        this.localStorageService.set('access_token', res.token);
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
