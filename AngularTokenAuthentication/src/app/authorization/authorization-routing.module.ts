import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { AdminComponent } from './admin/admin.component';
import { AuthGuardService } from '../authentication/services/auth-guard.service';
import { RoleGuardService } from '../authentication/services/role-guard.service';

const routes: Routes = [
  { path: 'user', component: UserComponent, canActivate : [AuthGuardService] },
  { path: 'admin', component: AdminComponent , canActivate : [RoleGuardService] , data : {expectedRole : "Administrator"}}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthorizationRoutingModule { }
