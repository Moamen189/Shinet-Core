import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CheckoutService } from '../../checkout.service';
import { BasketService } from 'src/app/basket/basket.service';
import { NavigationExtras, Router } from '@angular/router';
import { Basket } from 'src/app/shared/models/basket';
import { OrderToCreate } from 'src/app/shared/models/order';
import { Address } from 'src/app/shared/models/user';


@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements OnInit {

  @Input() checkoutForm?:FormGroup

  constructor(private toastr:ToastrService,
    private checkoutService:CheckoutService,
    private router:Router,
    private basketService:BasketService) { }

  ngOnInit(): void {
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
        console.log(order)
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
