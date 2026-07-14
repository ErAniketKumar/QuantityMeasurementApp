import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import {
  AuthResponse,
  LoginRequest,
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

  logout() {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getRole(): string {
    const token = localStorage.getItem('token');
    if (!token) return '';
    try {
      // Decode JWT payload
      const payload = JSON.parse(atob(token.split('.')[1]));
      // Note: role claim can be 'role', 'Role', or schemas...role
      const role = payload.role || payload.Role || payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '';
      return role;
    } catch {
      return '';
    }
  }

  isAdmin(): boolean {
    return this.getRole().toUpperCase() === 'ADMIN';
  }
}
