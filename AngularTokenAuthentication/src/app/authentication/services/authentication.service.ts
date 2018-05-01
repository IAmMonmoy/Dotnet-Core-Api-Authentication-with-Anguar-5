import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Login } from '../models/Login';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BaseService } from './base.service';
import { Register } from '../models/Register';

@Injectable()
export class AuthenticationService extends BaseService {

  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { super() }

  login(_login : Login)
  {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        })
      }

      return this.http.post(`${environment.baseUrl}/api/account/login`, _login, httpOptions)
        .pipe(
          catchError(val => this.handleError(new HttpErrorResponse(val)))
        );
  }

  register( _register : Register)
  {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        })
      }

      return this.http.post(`${environment.baseUrl}/api/account/register`, _register, httpOptions)
        .pipe(
          catchError(val => this.handleError(new HttpErrorResponse(val)))
        );
  }

  storeToken()
  {
    
  }
}
