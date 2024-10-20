import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDTO } from '../models/user.model';
import { jwtDecode } from 'jwt-decode'
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginUrl = 'http://localhost:5000/api/Auth/login'; 
  private getuserroleUrl = '';

  private userRole: number | null = null; // store role

  constructor(private http: HttpClient) { }

  // Call this after login to set the role
  setUserRole(role: number): void {
    this.userRole = role;
  }

  getUserRole(): string | null {
    if (this.userRole == 1) { return 'doctor' }
    else {return 'patient' }
  }



  login(email: string, password: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { email, password };

    return this.http.post(this.loginUrl, body, { headers });
  }

  saveToken(token: string): void {
    localStorage.setItem('jwtToken', token); // Save the token in local storage
  }

  getToken(): string | null {
    return localStorage.getItem('jwtToken'); // Retrieve token
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token; // Return true if a token exists
  }

  getUserInfo(): any {
    const token = localStorage.getItem('jwtToken');
    if (token) {
      const decodedToken = jwtDecode(token)||null;     
      return decodedToken;
    }
  }

  isDoctor(): boolean {
    const userData = this.getUserInfo();
    if (userData) {
      return userData.role === 'Doctor';
    }
    else {
      return false;
    }
  }
  isPatient(): boolean {
    const userData = this.getUserInfo();
    if (userData) {
      return userData.role === 'Patient';
    }
    else {
      return false;
    }
  }

  logout(): void {
    localStorage.removeItem('jwtToken'); // Remove token on logout
  }
}

