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

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private messageService: MessageService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        try {
          // Try convert defined errordto from server
          var errorDto = error.error as IErrorResultDto;
          var title = errorDto.statusCode.toString() + ' ' + errorDto.errorType;
          this.messageService.error(errorDto.message, title);
          return throwError(() => new Error(title));
        } catch {
          // Catch when errorDto cannot be converted, this happens when the server is not available
          this.messageService.error(error.message, 'Unbekannter Fehler');
          return throwError(() => new Error(error.message));
        }
      })
    );
  }
}
