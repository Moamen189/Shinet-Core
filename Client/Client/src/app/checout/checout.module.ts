import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChecoutRoutingModule } from './checout-routing.module';
import { CheckoutComponent } from './checkout/checkout.component';
import { SharedModule } from '../shared/shared.module';
import { CheckoutAddressComponent } from './checkout/checkout-address/checkout-address.component';
import { CheckoutDeliveryComponent } from './checkout/checkout-delivery/checkout-delivery.component';
import { CheckoutReviewComponent } from './checkout/checkout-review/checkout-review.component';
import { CheckoutPaymentComponent } from './checkout/checkout-payment/checkout-payment.component';
import { CheckoutSuccessComponent } from './checkout/checkout-success/checkout-success.component';


@NgModule({
  declarations: [
    CheckoutComponent,
    CheckoutAddressComponent,
    CheckoutDeliveryComponent,
    CheckoutReviewComponent,
    CheckoutPaymentComponent,
    CheckoutSuccessComponent
  ],
  imports: [
    CommonModule,
    ChecoutRoutingModule,
    SharedModule
  ]
})
export class ChecoutModule { }
