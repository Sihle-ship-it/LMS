import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {
  authors: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAuthors().subscribe({
      next: (data) => {
        this.authors = data;
        console.log(data);  // Ensure data is structured as expected.
      },
      error: (error) => console.error('Error fetching authors:', error)
    });
  }
}
