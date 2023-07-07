import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { Product } from 'src/app/shared/models/product';
import { Brand } from 'src/app/shared/models/Brands';
import { Type } from 'src/app/shared/models/Types';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  constructor(private ShopServices:ShopService) { }
  products:Product[]=[]
  Brands:Brand[] = []
  Types:Type[]=[]
  brandsIdSelected = 0
  typesIdSelected = 0

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this. getTypes();


  }

 getProducts(){

  this.ShopServices.getProduct(this.brandsIdSelected , this.typesIdSelected).subscribe({
    next:response=>this.products = response.data,
    error:error=>console.log(error)

  })


 }

 getBrands(){
  this.ShopServices.getBrands().subscribe({
    next:response=>this.Brands = [{id:0, name:'All'} , ...response],
    error:error=>console.log(error)

  })
 }
 getTypes(){

  this.ShopServices.getTypes().subscribe({
    next:response=>this.Types = [{id:0, name:'All'} , ...response],
    error:error=>console.log(error)

  })
 }

 onBrandSelected(brandId:number){
  this.brandsIdSelected = brandId
  this.getProducts();
 }

 onTypeSelected(typeId:number){
  this.typesIdSelected = typeId
  this.getProducts();
 }

}
