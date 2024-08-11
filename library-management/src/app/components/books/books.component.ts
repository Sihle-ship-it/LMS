import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getBooks().subscribe({
      next: (data) => {
        this.books = data;
        console.log(data);  // Ensure data is structured as expected.
      },
      error: (error) => console.error('Error fetching books:', error)
    });
  }
}
