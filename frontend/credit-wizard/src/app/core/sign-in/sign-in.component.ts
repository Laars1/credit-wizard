import { ILoginDto } from './../../shared/dtos/loginDto';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/api/auth.service';

/**
 * this component is the sign-in page of a web application.
 * It allows users to input their login credentials (username and password) and sends them to the server-side to be authenticated.
 */
@Component({
  selector: 'app-signin',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
})
export class SigninComponent implements OnInit {
  formGroup: FormGroup;
  constructor(
    public fb: FormBuilder,
    public authService: AuthService,
    public router: Router
  ) {
    this.formGroup = this.fb.group({
      username: [''],
      password: [''],
    });
  }
  ngOnInit() {
    if(this.authService.isLoggedIn){
      this.router.navigate(['dashboard'])
    }
  }

  /**
   * Sends a sign-in request to the authentication service using the form data.
   * If the request is successful, the user is logged in and redirected to the dashboard page.
   */
  loginUser() {
    const data = this.formGroup.getRawValue() as ILoginDto;
    this.authService.signIn(data);
  }
}