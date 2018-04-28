import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm : FormGroup;

  constructor(private fb : FormBuilder) { }

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
}
