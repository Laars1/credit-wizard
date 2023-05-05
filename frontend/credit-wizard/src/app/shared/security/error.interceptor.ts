import { MessageService } from './../services/common/message.service';
import { IErrorResultDto } from './../dtos/errorResultDto';
import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

/**
 * An interceptor that handles HTTP errors and shows an error message to the user.
 * If the error response contains an error DTO, it is displayed with a formatted title.
 * Otherwise, a generic error message is displayed with an "Unknown Error" title.
 */
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private messageService: MessageService) {}

  /**
   * Intercepts HTTP requests and handles HTTP errors.
   * If the error response contains an error DTO, it is displayed with a formatted title.
   * Otherwise, a generic error message is displayed with an "Unknown Error" title.
   * @param request The intercepted HTTP request.
   * @param next The next interceptor in the chain or the final HTTP handler if no more interceptors are available.
   * @returns An observable of the HTTP response event stream.
   */
  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        const errorDto = error.error as IErrorResultDto;
        if (errorDto) {
          const title = `${errorDto.statusCode} ${errorDto.errorType}`;
          this.messageService.error(errorDto.message, title);
          return throwError(() => new Error(title));
        } else {
          this.messageService.error(error.message, 'Unbekannter Fehler');
          return throwError(() => new Error(error.message));
        }
      })
    );
  }
}
