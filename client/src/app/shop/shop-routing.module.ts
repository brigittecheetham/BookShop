import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookDetailsComponent } from './book-details/book-details.component';
import { ShopComponent } from './shop.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: '', component: ShopComponent},
  {path: ':id', component: BookDetailsComponent},
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ShopRoutingModule { }
