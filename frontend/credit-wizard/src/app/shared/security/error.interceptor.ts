import { MessageService } from './../services/common/message.service';
import { ErrorResultDto } from './../dtos/errorResultDto';
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
        console.log(error);
        var errorDto = error.error as ErrorResultDto;
        var title = errorDto.statusCode.toString() + ' ' + errorDto.errorType;
        this.messageService.error(errorDto.message, title);
        return throwError(
          () => new Error(title)
        );
      })
    );
  }
}
