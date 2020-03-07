import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRegistrationService } from '../login-registration.service';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.css']
})
export class SignInPageComponent  {

  public username = '';
  public password = '';
  public BadInput = 1;
  public poruka = '';
  constructor(private route: Router, private loginRegistrationService: LoginRegistrationService) { }

  tryLogin() {
    this.loginRegistrationService.usernameLogin = this.username;
    this.loginRegistrationService.passwordLogin = this.password;
    this.loginRegistrationService.LoginUserAPI().then(l => {this.checkIfUserLoggedIn(); })
    .then(e => {this.BadInput = this.loginRegistrationService.userInfo.id; });
  }

    checkIfUserLoggedIn() {
    if (this.loginRegistrationService.successfulLoginRegistration === true) {
      this.poruka = '';
      this.route.navigate(['/']);
    } else {
      this.poruka = 'Wrong username or password!';
    }
  }

}
