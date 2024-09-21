import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterModel } from 'src/app/models/register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;
  submitted: boolean = false;

  constructor(private authService: AuthService, private fb: FormBuilder, private router: Router) {

  }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      firstname: ['', [Validators.required, Validators.minLength(2)]],
      lastname: ['', [Validators.required, Validators.minLength(2)]],
      username: ['', [Validators.required, Validators.minLength(4)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      email: ['', [Validators.required, Validators.email]],
      phonenumber: ['', [Validators.required]]
    });
  }

  get f() {
    return this.registerForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    //stop if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    const registerData: RegisterModel = {
      firstname: this.f['firstname'].value,
      lastname: this.f['lastname'].value,
      username: this.f['username'].value,
      password: this.f['password'].value,
      phonenumber: this.f['phonenumber'].value,
      email: this.f['email'].value
    };

    this.authService.register(registerData).subscribe({
      next: () => {
        this.router.navigate(['/auth/login']);
      },
      error: (err) => {
        console.error("Registration failed", err);
      }
    });
  }
}
