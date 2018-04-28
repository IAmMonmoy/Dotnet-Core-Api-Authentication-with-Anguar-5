import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validators, FormGroup } from '@angular/forms';
import { Login } from '../models/Login';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm : FormGroup;
  login : Login;

  constructor(private fb : FormBuilder, private _authService: AuthenticationService) { }

  ngOnInit() {
    this.createForm();
  }

  createForm()
  {
    this.loginForm = this.fb.group({
        Email : ['', Validators.required],
        Password : ['', Validators.required]
    });
  }

  onSubmit()
  {
      this.login = new Login();
      this.login.Email = this.loginForm.controls.Email.value;
      this.login.Password = this.loginForm.controls.Password.value;
      this._authService.login(this.login).subscribe( val => {
          console.log(val);
      });
  }
}
