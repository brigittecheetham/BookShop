import { Component, OnInit } from '@angular/core';
import { IBook } from 'src/app/shared/models/book';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent implements OnInit {
  book: IBook;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadBook();
  }

  loadBook() {
    this.shopService.getBook(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(book => {
      this.book = book;
    }, error => {
      console.log(error);
    });
  }

}
