import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChecoutRoutingModule } from './checout-routing.module';
import { CheckoutComponent } from './checkout/checkout.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    CheckoutComponent
  ],
  imports: [
    CommonModule,
    ChecoutRoutingModule,
    SharedModule
  ]
})
export class ChecoutModule { }
