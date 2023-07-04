import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/Paging';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Shinet Store';
  constructor(private httpClient:HttpClient){}
  products:any[] = [];
  ngOnInit(): void {
    this.httpClient.get<Pagination<Product[]>>("https://localhost:44398/api/Product?pageSize=50").subscribe({
      next:(response) =>{
        console.log(response),

        this.products = response.data
      },

      error:error => console.log(error),
      complete: ()=> {
        console.log("Request Completed")
        console.log("extra Staments")
      }

    })
  }
}
