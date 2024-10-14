import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Appointment } from '../models/appointment.model'; // Import your Appointment model
import { UserDTO } from '../models/user.model';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private getAllAppointmentsAPI = 'http://localhost:5000/api/Appointments/GetAllAppointments'; // Update with your backend API URL

  private createUserAPI = 'http://localhost:5000/api/User/CreateUser';


  constructor(private http: HttpClient) { }

  getAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(this.getAllAppointmentsAPI); // Make GET request to the API
  }

  createUser(user: UserDTO): Observable<UserDTO> {
    return this.http.post<UserDTO>(this.createUserAPI, user);
  }
}

