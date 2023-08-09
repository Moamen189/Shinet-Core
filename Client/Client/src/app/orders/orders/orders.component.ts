import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/models/order';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  orders:Order[] = [];

  constructor(private OrderService:OrdersService) { }

  ngOnInit(): void {
    this.getOrders();
  }


  getOrders(){

    this.OrderService.getOrdersForUser().subscribe({
      next : orders => this.orders = orders
    })
  }

}
