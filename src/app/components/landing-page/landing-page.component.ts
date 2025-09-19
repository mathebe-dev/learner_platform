import { Component } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { LoginComponent } from "../login/login.component";

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [RegisterComponent, LoginComponent],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.scss'
})
export class LandingPageComponent {
  showRegister = false;
  showLogin = false;

  toggleRegister() {
    this.showRegister = !this.showRegister;
    this.showLogin = false; // close login if open
  }

  toggleLogin() {
    this.showLogin = !this.showLogin;
    this.showRegister = false; // close register if open
  }
}
