import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'http://localhost:5000/api/Auth/login';  // Replace with your actual API URL

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { email, password };

    return this.http.post(this.apiUrl, body, { headers });
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

  logout(): void {
    localStorage.removeItem('jwtToken'); // Remove token on logout
  }
}

