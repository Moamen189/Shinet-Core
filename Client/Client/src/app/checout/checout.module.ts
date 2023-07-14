import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChecoutRoutingModule } from './checout-routing.module';
import { CheckoutComponent } from './checkout/checkout.component';


@NgModule({
  declarations: [
    CheckoutComponent
  ],
  imports: [
    CommonModule,
    ChecoutRoutingModule
  ]
})
export class ChecoutModule { }
