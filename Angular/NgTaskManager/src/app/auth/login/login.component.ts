import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/login.model';
import { AuthResponse } from 'src/app/models/auth-response.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  submitted: boolean = false;
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private fb: FormBuilder, private router: Router) {

  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  get f() {
    return this.loginForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    this.errorMessage = null;

    //stop if the form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    const loginData: LoginModel = {
      email: this.f['email'].value,
      password: this.f['password'].value
    }

    this.authService.login(loginData).subscribe({
      next: (response: AuthResponse) => {
        localStorage.setItem('token', response.Token);
        this.router.navigate(['/tasks']);
      },
      error: (err) => {
        this.errorMessage = 'Invalid Login Attempt';
        console.error("Login failed", err);
      }
    });
  }
}
