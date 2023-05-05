import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
} from '@angular/common/http';
import { AuthService } from '../services/api/auth.service';

/**
 * intercepts the outgoing HTTP requests and adds the authorization token to the request header. 
 * This is done to authorize the user and allow them to access protected resources.
 */
@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  /**
   * Intercept the outgoing HTTP requests and add the authorization token to the request header.
   * @param req - The HTTP request.
   * @param next - The HTTP request handler.
   */
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    // Get the authorization token.
    const authToken = this.authService.getToken();

    // Add the authorization token to the request header.
    req = req.clone({
      setHeaders: {
        Authorization: "Bearer " + authToken
      }
    });

    // Return the HTTP request with the authorization token.
    return next.handle(req);
  }
}
