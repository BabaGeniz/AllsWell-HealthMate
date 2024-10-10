import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';  // Import HeaderComponent
import { BannerComponent } from './banner/banner.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http'

import { routes } from './app.routes' // Import the routes from your routes.ts file

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,  // Declare the HeaderComponent here
    BannerComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes)  // Set up routing by using RouterModule.forRoot
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


