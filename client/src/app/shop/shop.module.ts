import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { BookClientComponent } from './book-client/book-client.component';
import { SharedModule } from '../shared/shared.module';
import { BookDetailsComponent } from './book-details/book-details.component';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [ShopComponent, BookClientComponent, BookDetailsComponent],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule
  ],
  //exports: [ShopComponent] dont need after implementing shop rooting module
})
export class ShopModule { }
