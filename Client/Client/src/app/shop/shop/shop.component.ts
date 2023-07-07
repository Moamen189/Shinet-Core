import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { Product } from 'src/app/shared/models/product';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  constructor(private ShopServices:ShopService) { }
  products:Product[]=[]
  ngOnInit(): void {
    this.ShopServices.getProduct().subscribe({
      next:response=>this.products = response.data,
      error:error=>console.log(error)

    })
  }

}
