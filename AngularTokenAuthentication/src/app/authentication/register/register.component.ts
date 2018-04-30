import { Component, OnInit } from '@angular/core';
import { FormBuilder ,FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm : FormGroup;

  constructor(private fb: FormBuilder, private _authService: AuthenticationService) { }

  ngOnInit() {
      this.createForm();
  }

  createForm()
  {
    this.registerForm = this.fb.group({
        Email : ['', [Validators.required,Validators.email]],
        UserName: ['', [Validators.required, Validators.min(2)]],
        Password : ['', Validators.required],
        ConfirmPassword : ['', Validators.required]
      }
    )
  }
}
