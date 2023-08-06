import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { SharedRoutingModule } from './shared-routing.module';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { BasketSummaryComponent } from './basket-summary/basket-summary.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { StepperComponent } from './components/stepper/stepper.component';
import {CdkStepperModule} from '@angular/cdk/stepper';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    BasketSummaryComponent,
    StepperComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    CdkStepperModule
  ],
  exports:[PaginationModule , PagingHeaderComponent , PagerComponent , CarouselModule , OrderTotalsComponent , BasketSummaryComponent , ReactiveFormsModule , BsDropdownModule , CdkStepperModule , StepperComponent]
})
export class SharedModule { }
