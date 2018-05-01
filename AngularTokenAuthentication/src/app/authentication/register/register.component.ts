import { Component, OnInit } from '@angular/core';
import { FormBuilder ,FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { Register } from '../models/Register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm : FormGroup;
  registerModel: Register;

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

  onSubmit()
  {
      this.registerModel = new Register();
      this.registerModel.Email = this.registerForm.controls.Email.value;
      this.registerModel.UserName = this.registerForm.controls.UserName.value;
      this.registerModel.Password = this.registerForm.controls.Password.value;
      this.registerModel.ConfirmPassword = this.registerForm.controls.ConfirmPassword.value;
      
      this._authService.register(this.registerModel).subscribe( val => {
          console.log(val);
      });

      this.registerForm.reset();
  }
}
