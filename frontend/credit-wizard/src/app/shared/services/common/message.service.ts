import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

constructor(private toastr: ToastrService) { }

success(message: string, title?: string){
  if(title != undefined){
    this.toastr.success(message, title)
  }
  else{
    this.toastr.success(message)
  }
}

error(message: string, title?: string){
  if(title != undefined){
    this.toastr.error(message, title)
  }
  else{
    this.toastr.error(message)
  }
}

}
