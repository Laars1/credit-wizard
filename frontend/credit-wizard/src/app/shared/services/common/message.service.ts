import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

/**
 * Service which is responsible for handling the messaging of the application
 */
@Injectable({
  providedIn: 'root',
})
export class MessageService {
  constructor(private toastr: ToastrService) {}

  /**
   * show a success message to the user
   * @param message content which should be shown
   * @param title title of the shown message
   */
  success(message: string, title?: string) {
    this.toastr.success(message, title);
  }

  /**
   * show a error message to the user
   * @param message content which should be shown
   * @param title title of the shown message
   */
  error(message: string, title?: string) {
    this.toastr.error(message, title);
  }
}
