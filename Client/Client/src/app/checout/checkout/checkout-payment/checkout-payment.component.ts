import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CheckoutService } from '../../checkout.service';
import { BasketService } from 'src/app/basket/basket.service';
import { NavigationExtras, Router } from '@angular/router';
import { Basket } from 'src/app/shared/models/basket';
import { OrderToCreate } from 'src/app/shared/models/order';
import { Address } from 'src/app/shared/models/user';
import { loadStripe, Stripe, StripeCardCvcElement, StripeCardExpiryElement, StripeCardNumberElement } from '@stripe/stripe-js';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements OnInit {

  @Input() checkoutForm?:FormGroup
  @ViewChild('cardNumber') cardNumberElement?:ElementRef;
  @ViewChild('cardExpiry') cardExpiryElement?:ElementRef;
  @ViewChild('cardCvc') cardCvcElement?:ElementRef;

  stripe:Stripe|null=null;
  cardNumber?:StripeCardNumberElement;
  cardExpiry?:StripeCardExpiryElement;
  cardCvc?:StripeCardCvcElement;

  cardErrors:any;
  constructor(private toastr:ToastrService,
    private checkoutService:CheckoutService,
    private router:Router,
    private basketService:BasketService) { }

    ngOnInit(): void {
      loadStripe('pk_test_51MkWvgJYk4zZyAMfRoFm71GR1wD7EidwWRzr4o9UaPl3IyN32JSsUEw3Yymleeo9hJpbOz6Ih61WRymBR2jfCZvj00PJ2gKGu4').then(stripe=>{
        this.stripe=stripe;
        const elements=stripe?.elements();
        if(elements)
        {
          this.cardNumber=elements.create('cardNumber');
          this.cardNumber.mount(this.cardNumberElement?.nativeElement);
          this.cardNumber.on('change',event=>{
            if(event.error)this.cardErrors=event.error.message
            else this.cardErrors=null
          })

          this.cardExpiry=elements.create('cardExpiry');
          this.cardExpiry.mount(this.cardExpiryElement?.nativeElement);
          this.cardExpiry.on('change',event=>{
            if(event.error)this.cardErrors=event.error.message
            else this.cardErrors=null
          })

          this.cardCvc=elements.create('cardCvc');
          this.cardCvc.mount(this.cardCvcElement?.nativeElement);
          this.cardCvc.on('change',event=>{
            if(event.error)this.cardErrors=event.error.message
            else this.cardErrors=null
          })
        }
      })
    }


  submitOrder()
  {

    const basket=this.basketService.getCurrentBsketValue();
    if(!basket) throw new Error('Cannot get the basket');

    const orderToCreate = this.getOrderToCreate(basket);
    if(!orderToCreate) return

    this.checkoutService.createOrder(orderToCreate).subscribe({
      next:order => {
        this.toastr.success('Order Created Successfully');
        this.basketService.deleteLocalBasket();
        const navigationExtras:NavigationExtras ={state:order};
            this.router.navigate(['checkout/success'],navigationExtras);
      }
    })



    // try {
    //   const createdOrder= await this.createOrder(basket);
    //   const paymentResult= await this.confirmPaymentWithStripe(basket);
    //   if(paymentResult.paymentIntent)
    //       {
    //         this.basketService.deleteBasket(basket);
    //         const navigationExtras:NavigationExtras ={state:createdOrder};
    //         this.router.navigate(['checkout/success'],navigationExtras);
    //       }
    //       else
    //       {
    //         this.toastr.error(paymentResult.error.message)
    //       }
    // } catch (error:any) {
    //   this.toastr.error(error.message);
    // }
  }








  private getOrderToCreate(basket:Basket):OrderToCreate
  {
    const deliveryMethodId=this.checkoutForm?.get('deliveryForm')?.get('deliveryMethod')?.value;
    const shippToAddress= this.checkoutForm?.get('addressForm')?.value as Address;

    if(!deliveryMethodId || !shippToAddress) throw new Error('Problem with basket');

    return {
      basketId:basket.id,
      deliveryMethodId:deliveryMethodId,
      shipToAddress:shippToAddress

    }
  }
}
