import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Appointment } from '../models/appointment.model'; // Import your Appointment model
import { User, UserDTO } from '../models/user.model';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private getAllAppointmentsAPI = 'http://localhost:5000/api/Appointments/GetAllAppointments'; 
  private createUserAPI = 'http://localhost:5000/api/User/CreateUser';
  private UserAPI = 'http://localhost:5000/api/User';


  constructor(private http: HttpClient) { }

  getAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(this.getAllAppointmentsAPI); // Make GET request to the API
  }

  createUser(user: UserDTO): Observable<UserDTO> {
    return this.http.post<UserDTO>(this.createUserAPI, user);
  }

  getUsersByRole(role: number): Observable<User[]> {
    const url = `${this.UserAPI}/GetUsersByRole/${role}`;
    return this.http.get<User[]>(url);
  }
  getUserById(id: number): Observable<User> {
    const url = `${this.UserAPI}/GetUserByID/${id}`;
    return this.http.get<User>(url);
  }
}

