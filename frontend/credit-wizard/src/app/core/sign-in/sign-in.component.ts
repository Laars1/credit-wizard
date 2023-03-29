import { LoginDto } from './../../shared/dtos/loginDto';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/api/auth.service';
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
  ngOnInit() {}

  loginUser() {
    const data = this.formGroup.getRawValue() as LoginDto;
    this.authService.signIn(data);
  }
}