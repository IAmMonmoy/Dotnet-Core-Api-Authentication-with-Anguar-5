import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { AdminComponent } from './admin/admin.component';
import { UserComponent } from './user/user.component';
import { AuthGuardService } from '../authentication/services/auth-guard.service';

@NgModule({
  imports: [
    CommonModule,
    AuthorizationRoutingModule
  ],
  providers : [AuthGuardService]
  ,
  declarations: [AdminComponent, UserComponent]
})
export class AuthorizationModule { }
