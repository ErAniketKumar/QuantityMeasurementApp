import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import {
  AuthResponse,
  LoginRequest,
  LoginWithGoogle,
  RegisterRequest,
} from '../models/auth.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  private apiUrl = `${environment.apiUrl}/auth`;
  register(data: RegisterRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, data);
  }

  login(data: LoginRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, data);
  }

  googleAuth(idToken: string) {
    return this.http.post<AuthResponse>(`${this.apiUrl}/google`, { idToken });
  }
}
