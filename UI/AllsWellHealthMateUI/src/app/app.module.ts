import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './login/signup/signup.component';
import { CreatehealthrecordComponent } from '../app/healthrecord/createhealthrecord/createhealthrecord.component';
import { HeaderComponent } from './header/header.component';  // Import HeaderComponent
import { BannerComponent } from './banner/banner.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select'; // Import MatSelectModule
import { MatOptionModule } from '@angular/material/core'; // Import MatOptionModule
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';  // <-- Import this


import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async' // Import the routes from your routes.ts file

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,  // Declare the HeaderComponent here
    BannerComponent,
    HomeComponent,
    LoginComponent,
    SignupComponent,
    CreatehealthrecordComponent    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatIconModule,
    MatOptionModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)  // Set up routing by using RouterModule.forRoot
  ],
  bootstrap: [AppComponent],
  providers: [
    provideAnimationsAsync()
  ]
})
export class AppModule { }


