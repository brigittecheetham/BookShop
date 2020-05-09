import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IGenre } from '../shared/models/genre';
import { IBook } from '../shared/models/book';
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
      params = params.append('genreId', shopParams.genreIdSelected.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sortSelected);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'books', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getBook(id: number) {
    return this.http.get<IBook>(this.baseUrl + 'books/' + id);
  }

  getGenres() {
    return this.http.get<IGenre[]>(this.baseUrl + 'books/genres');
  }
}
