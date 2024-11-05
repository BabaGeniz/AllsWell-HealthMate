import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router'; // Import Router


@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrl: './banner.component.css'
})
export class BannerComponent {
  constructor(public authService: AuthService, private router: Router) { }

  navigateToCreateHealthRecord() {
    this.router.navigate(['/createhealthrecord']); // Navigate to /healthrecord
  }
}
