import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { 

  }

  ngOnInit(): void {
  }

  get404Error() {
    this.http.get(this.baseUrl + 'books/800').subscribe(response => {
      console.log('found book');
    }, error => {
      console.log(error);
    });
  }

  get400ValidationError() {
    this.http.get(this.baseUrl + 'books/eighthundred').subscribe(response => {
      console.log('found book');
    }, error => {
      console.log(error);
    });
  }
}
