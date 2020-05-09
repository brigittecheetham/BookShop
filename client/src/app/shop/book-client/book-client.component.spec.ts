import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookClientComponent } from './book-client.component';

describe('BookClientComponent', () => {
  let component: BookClientComponent;
  let fixture: ComponentFixture<BookClientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookClientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
