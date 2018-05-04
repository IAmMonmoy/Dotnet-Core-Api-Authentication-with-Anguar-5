import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class RoleGuardService {

  constructor(private _auth: AuthenticationService, private router: Router) { }
  canActivate(route : ActivatedRouteSnapshot) : boolean
  {
    const expectedRole = route.data.expectedRole;

      const tokenPayload = this._auth.decodeToken();

      //check the role form token includes the role we are looking for
      if(this._auth.isAuthenticated())
      {
          if(tokenPayload.Rol == expectedRole)
            return true;
      }
     
      this.router.navigate(['login']);
      return false;
  }
}
