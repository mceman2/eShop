import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { User } from './User.model';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginRegistrationService {
  constructor(private http: HttpClient, private route: Router) { }

  public successfulLoginRegistration: boolean;

  public userInfo: User = {id: 0, username : '', password : '', role: 1};
  public usernameLogin = '';
  public passwordLogin = '';

  private urlAPI = 'https://localhost:44387/api/user';

  public async LoginUserAPI(): Promise<any> {
    return await this.http.get<number>(this.urlAPI + '?username=' + this.usernameLogin + '&password=' + this.passwordLogin)
    .toPromise().then(data => {this.userInfo.id = data}).catch((error: HttpErrorResponse) => {this.userInfo.id = 0;})
    .then(d => {this.changingLoginStatus(); });
  }

    public changingLoginStatus() {
    if (this.userInfo.id > 0 && this.userInfo.id !== undefined) {
      this.successfulLoginRegistration = true;
    }
  }

  public Logout() {
    this.userInfo = {id: 0, username: '', password : '', role : 0};
    this.successfulLoginRegistration = false;
    this.route.navigate(['/']);
  }

  public async RegisterUserAPI(user: User): Promise<any> {
    const headerHttp = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    
    const newUserInfo: User = {username : user.username, password : user.password, role: +user.role};

    return await this.http.post<number>(this.urlAPI, newUserInfo, headerHttp)
    .toPromise().then(data => {this.userInfo.id = data; this.changingLoginStatus()});
  }
}
