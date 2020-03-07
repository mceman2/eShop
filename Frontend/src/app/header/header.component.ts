import { Component, OnInit } from '@angular/core';
import { LoginRegistrationService } from '../login-registration.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private service: LoginRegistrationService) { }

  ngOnInit() {
  }

}
