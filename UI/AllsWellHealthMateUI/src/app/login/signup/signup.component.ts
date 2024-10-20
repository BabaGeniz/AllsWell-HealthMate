import { Component } from '@angular/core';
import { Provider, UserCreate, UserDTO } from '../../models/user.model';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router'; // Import Router
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  accountType: string | null = null;
  email: string = '';
  password: string = '';
  firstname: string = '';
  lastname: string = '';
  licenseNumber: string = '';
  specialization: string = '';

  constructor(private apiService: ApiService, private router: Router, public authService: AuthService) { }

  selectAccountType(type: string): void {
    
    this.accountType = type;
  }

  isSelected(type: string): boolean {
    
    return this.accountType === type;
  }

  
  signup(): void {
    const userData: UserCreate = {
      firstName: this.firstname,
      lastName: this.lastname,
      email: this.email,
      password: this.password,
      userRole: this.accountType === 'doctor' ? 1 : 2, // Assuming 1 for doctor, 2 for patient
    };

    const provider: Provider = {
      specialization: this.specialization,
      hospitalAffiliation: this.licenseNumber
    };

    const userDTO: UserDTO = {
      userCreateDTO: userData,
      providerDTO: provider
    }

    this.authService.setUserRole(userData.userRole);
    
    this.apiService.createUser(userDTO).subscribe(
      (response) => {
        console.log('Data sent successfully:', response);
        this.router.navigate(['/login']);
      }, error => {
        console.error('Error sending data:', error);
      }
    );    

  }
}
