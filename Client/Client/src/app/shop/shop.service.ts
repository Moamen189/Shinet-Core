import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/Paging';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/Brands';
import { Type } from '../shared/models/Types';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http:HttpClient) { }
  baseUrl = "https://localhost:44398/api/"
  getProduct(brandId?:number , typeId?:number , sort?:string){
    let params = new HttpParams();
    if(brandId){
      params = params.append('brandId', brandId)
    }
    if(typeId){
      params = params.append('typeId' , typeId)
    }

    if(sort){
      params = params.append('sort' , sort)
    }
    return this.http.get<Pagination<Product[]>>(this.baseUrl +'Product' , {params:params})
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseUrl+'Product/brands')
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl + 'Product/types')
  }


}
