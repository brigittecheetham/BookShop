import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IPagination } from '../shared/models/pagination';
import { ICategory } from '../shared/models/category';
import { ShopParams } from '../shared/models/shopparams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  books: IProduct[];
  genres: ICategory[];
  shopParams = new ShopParams();
  totalCount: number;

  sortOptions = [
    {name: 'Alphabetical', value: 'nameAsc'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'},
    {name: 'Genre', value: 'nameDesc'}  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getBooks();
    this.getGenres();
  }

  getBooks() {
    this.shopService.getBooks(this.shopParams).subscribe((response: IPagination) => {
      this.books = response.data;
      this.shopParams.pageSize = response.pageSize;
      this.shopParams.pageNumber = response.pageIndex;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getGenres() {
    this.shopService.getGenres().subscribe(response => {
      this.genres = [{id: 0, name: 'All'}, ...response]
    }, error => {
      console.log(error);
    });
  }

  onGenreSelected(genreId: number) {
    this.shopParams.genreIdSelected = genreId;
    this.shopParams.pageNumber = 0;
    this.getBooks();
  }

  onSortSelected(sort: string) {
    this.shopParams.sortSelected = sort;
    this.getBooks();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event-1) {
      this.shopParams.pageNumber = event-1;
      this.getBooks();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 0;
    this.getBooks();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getBooks();
  }
}
