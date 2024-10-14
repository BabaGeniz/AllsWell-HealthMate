import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
 ;

  login(): void {
    if (this.email && this.password) {
      // Handle login logic
      console.log(`Logging in with email: ${this.email}`);
    } else {
      alert('Please fill all fields');
    }
  }
}
