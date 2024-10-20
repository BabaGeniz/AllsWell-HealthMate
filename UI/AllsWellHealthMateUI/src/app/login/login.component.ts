import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router'; // Import Router

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }
  
  login(): void {
    
    this.authService.login(this.email, this.password).subscribe(
      (response) => {
        const token = response.token;
        this.authService.saveToken(token);
     
        console.log('Login successful! Token:', token);
        this.errorMessage = '';
        this.router.navigate(['/home']);

      },
      (error) => {
        console.error('Login failed:', error);
        this.errorMessage = "Incorrect UserName or Password. Try Again!";

      }
    );  
    
  }
}
