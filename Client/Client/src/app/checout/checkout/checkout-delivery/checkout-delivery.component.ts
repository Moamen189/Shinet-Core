import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CheckoutService } from '../../checkout.service';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm?:FormGroup
  deliveryMethods:DeliveryMethod[]=[]
  constructor(private checkoutServices:CheckoutService) { }

  ngOnInit(): void {
    this.checkoutServices.getDeliveryMethods().subscribe({
      next:dm => this.deliveryMethods = dm

    })
  }

}
