import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { LoginComponent } from './authentication/login/login.component';
import { AppComponent } from './app.component';

const routes : Routes = [
  { path: '', component: AppComponent }
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
