import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { Product } from 'src/app/shared/models/product';
import { Brand } from 'src/app/shared/models/Brands';
import { Type } from 'src/app/shared/models/Types';
import { HttpParams } from '@angular/common/http';
import { ShopParams } from 'src/app/shared/models/ShopParams';

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
  totalCount =0;

  shopParams = new ShopParams();
  sortOptions=[
    {name:'Alphabetical' , value:'Name'},
    {name:'Price : Low to High' , value:'priceAsc'},
    {name:'Price : High to Low' , value:'priceDsc'},

  ]

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this. getTypes();


  }

 getProducts(){

  this.ShopServices.getProduct(this.shopParams).subscribe({
    next:response=>{this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;

    },
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
  this.shopParams.brandId = brandId
  this.getProducts();
 }

 onTypeSelected(typeId:number){
  this.shopParams.typeId = typeId
  this.getProducts();
 }

 onSortSelected(event:any){
  this.shopParams.sort = event.target.value
  this.getProducts()
 }

 onPageChanged(event:any){

  if(this.shopParams.pageNumber !== event.page){

    this.shopParams.pageNumber = event.page
    this.getProducts()
  }

 }

}
