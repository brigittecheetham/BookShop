import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-book-client',
  templateUrl: './book-client.component.html',
  styleUrls: ['./book-client.component.scss']
})
export class BookClientComponent implements OnInit {
  @Input() book: IProduct;

  constructor() { }

  ngOnInit(): void {
  }

}
