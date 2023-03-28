import { LoginDto } from '../../dtos/loginDto';
import { Injectable } from '@angular/core';
import { ApiService } from '../base/api.service';
import { LocalStorageService } from '../common/local-storage.service';
import { TokenDto } from '../../dtos/tokenDto';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = 'authentication';
  constructor(private apiService: ApiService, private localStorageService: LocalStorageService) {}

  signIn(user: LoginDto) {
    return this.apiService
      .post<TokenDto>('/login', user)
      .subscribe((res: any) => {
        this.localStorageService.set('access_token', res.token);
      });
  }

  getToken() {
    return localStorage.getItem('access_token');
  }

  get isLoggedIn(): boolean {
    let authToken = this.localStorageService.get('access_token');
    return authToken !== null ? true : false;
  }
}
