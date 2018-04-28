import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { UserComponent } from './authorization/user/user.component';

const routes : Routes = [
  { path: '', component: UserComponent }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
  ,
  declarations: []
})
export class AppRoutingModule { }
