import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Login } from '../models/Login';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BaseService } from './base.service';
import { Register } from '../models/Register';
import { responseTokenObject } from '../models/reponseTokenObject';

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

  storeToken(val)
  {
      var responseObject = new responseTokenObject();
      responseObject = eval(val);
      localStorage.setItem('Token',responseObject.auth_token);
  }

  getToken()
  {
      return localStorage.getItem('Token'); 
  }

  isAuthenticated()
  {
      return !this.jwtHelper.isTokenExpired(this.getToken());
  }

  decodeToken()
  {
     return this.jwtHelper.decodeToken(this.getToken());
  }

  deleteToken()
  {
     return localStorage.removeItem('Token');
  }
}
