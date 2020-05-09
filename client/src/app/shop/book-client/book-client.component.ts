import { Component, OnInit, Input } from '@angular/core';
import { IBook } from 'src/app/shared/models/book';

@Component({
  selector: 'app-book-client',
  templateUrl: './book-client.component.html',
  styleUrls: ['./book-client.component.scss']
})
export class BookClientComponent implements OnInit {
  @Input() book: IBook;

  constructor() { }

  ngOnInit(): void {
  }

}
