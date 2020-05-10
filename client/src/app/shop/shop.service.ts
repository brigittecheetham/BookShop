import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { ICategory } from '../shared/models/category';
import { IProduct } from '../shared/models/product';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopparams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getBooks(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.genreIdSelected) {
      params = params.append('categoryId', shopParams.genreIdSelected.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sortSelected);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getBook(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getGenres() {
    return this.http.get<ICategory[]>(this.baseUrl + 'products/categories');
  }
}
