import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/Paging';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http:HttpClient) { }
  baseUrl = "https://localhost:44398/api/"
  getProduct(){
    return this.http.get<Pagination<Product[]>>(this.baseUrl +'Product?pageSize=50')
  }


}
