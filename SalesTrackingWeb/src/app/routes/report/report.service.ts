// report.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ReportService {
  private apiUrl = 'https://localhost:7181/'; // API URL

  constructor(private http: HttpClient) {}

  // Method to register a customer (POST request)
  getReport(reportData: any): Observable<any> {
    return this.http
      .post<any>(this.apiUrl+'api/report', reportData, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      })
      .pipe(
        catchError((error) => {
          console.error('API Error:', error);
          throw error;
        })
      );
  }
}
