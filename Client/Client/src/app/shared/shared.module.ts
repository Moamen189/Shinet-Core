import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { SharedRoutingModule } from './shared-routing.module';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { BasketSummaryComponent } from './basket-summary/basket-summary.component';


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    BasketSummaryComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
  ],
  exports:[PaginationModule , PagingHeaderComponent , PagerComponent , CarouselModule , OrderTotalsComponent , BasketSummaryComponent]
})
export class SharedModule { }
