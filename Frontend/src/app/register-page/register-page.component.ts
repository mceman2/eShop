import { Component, OnInit } from '@angular/core';
import { User } from '../User.model';
import { Router } from '@angular/router';
import { LoginRegistrationService } from '../login-registration.service';


@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {

  user: User = { username: '', password: '', role: 0};


  constructor(private route: Router, private loginRegistrationService: LoginRegistrationService) { }

  ngOnInit() {
  }

  SignUp() {
    this.loginRegistrationService.RegisterUserAPI(this.user).then(d => this.checkIfUserLoggedIn());
  }
  checkIfUserLoggedIn() {
    if (this.loginRegistrationService.successfulLoginRegistration === true) {
      this.route.navigate(['/']);
    }
  }

}
