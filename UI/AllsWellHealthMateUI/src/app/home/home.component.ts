import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  constructor(public authService: AuthService) { }
  public email = '';
  public id = '';
  public role = '';

  ngOnInit() {
    const decodedToken = this.authService.getUserInfo();
    if (decodedToken) {
      console.log(decodedToken.email);
      console.log(decodedToken.nameid);
      console.log(decodedToken.role);

      this.email = decodedToken.email;
      this.id = decodedToken.nameid;
      this.role = decodedToken.role;
    }  
  }
}
