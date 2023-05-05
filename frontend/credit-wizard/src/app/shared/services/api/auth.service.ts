import { ILoginDto } from './../../dtos/loginDto';
import { Injectable, Type } from '@angular/core';
import { ApiService } from './base/api.service';
import { LocalStorageService } from '../common/local-storage.service';
import { ITokenDto } from '../../dtos/tokenDto';
import { Router } from '@angular/router';

/**
 * API Service for handling authentication requests
 */
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

  /**
   * Send loginDto to API by HTTP Post Request
   * After successful login the returned token is set to the local storage
   * @param user data which should be sent to the API
   */
  signIn(user: ILoginDto) {
    this.apiService
      .post<ITokenDto, ILoginDto>(this.apiUrl + '/login', user)
      .subscribe((res: any) => {
        this.localStorageService.set('access_token', res.token);
        this.router.navigate(['dashboard']);
      });
  }

  /**
   * Logout the user from the Application
   * token is removed from localstorage
   */
  logout() {
    let removeToken = localStorage.removeItem('access_token');
    if (removeToken == null) {
      this.router.navigate(['login']);
    }
  }

  /**
   * Get token from localstorage
   * @returns {sting | null} token from local storage
   */
  getToken() {
    return localStorage.getItem('access_token');
  }

  /**
   * bool property which indicates if user has a token or not
   */
  get isLoggedIn(): boolean {
    let authToken = this.localStorageService.get('access_token');
    return authToken !== null ? true : false;
  }
}
