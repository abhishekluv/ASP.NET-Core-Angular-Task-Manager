import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(private authService: AuthService, private router: Router) {
  }

  get isLoggedIn() {
    return this.authService.isLoggedIn();
  }

  get username() {
    return this.authService.getToken() ? 'User' : null;
  }

}
