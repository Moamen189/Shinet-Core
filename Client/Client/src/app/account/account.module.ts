import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountRoutingModule } from './account-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,


  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule,

    FormsModule,
    ReactiveFormsModule
  ]
})
export class AccountModule { }
