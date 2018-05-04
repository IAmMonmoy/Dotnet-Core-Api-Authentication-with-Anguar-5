import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private _authenticationService : AuthenticationService) { }

  ngOnInit() {
  }

  logOut()
  {
      this._authenticationService.deleteToken();
  }

}
