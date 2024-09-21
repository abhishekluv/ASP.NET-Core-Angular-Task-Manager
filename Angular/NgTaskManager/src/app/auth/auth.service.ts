import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { RegisterModel } from "../models/register.model";
import { LoginModel } from "../models/login.model";
import { AuthResponse } from "../models/auth-response.model";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private apiUrl: string = "https://localhost:7060/api/auth";

    constructor(private http: HttpClient) {

    }

    register(user: RegisterModel): Observable<any> {
        return this.http.post(`${this.apiUrl}/register`, user);
    }

    login(credentials: LoginModel): Observable<AuthResponse> {
        return this.http.post<AuthResponse>(`${this.apiUrl}/login`, credentials);
    }

    logout() {
        localStorage.removeItem('token');
    }

    getToken(): string | null {
        return localStorage.getItem('token');
    }

    isLoggedIn(): boolean {
        return !!this.getToken();
    }
}