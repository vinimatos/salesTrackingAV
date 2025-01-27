// customer.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  private apiUrl = 'https://localhost:7181/'; // API URL

  constructor(private http: HttpClient) {}



  // Method to fetch customer data (GET request)
  getAll(): Observable<any> {
    return this.http.get<any>(this.apiUrl+'api/dashboard').pipe(
      catchError((error) => {
        console.error('API Error:', error);
        throw error;
      })
    );
  }
}
