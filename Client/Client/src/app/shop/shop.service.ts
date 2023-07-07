import { HttpClient } from '@angular/common/http';
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
  getProduct(){
    return this.http.get<Pagination<Product[]>>(this.baseUrl +'Product?pageSize=50')
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseUrl+'Product/brands')
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl + 'Product/types')
  }


}
