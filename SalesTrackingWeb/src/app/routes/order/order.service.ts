// product.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  private apiUrl = 'https://localhost:7181/'; // API URL

  constructor(private http: HttpClient) {}

  // Method to register a order (POST request)
  add(orderData: any): Observable<any> {
    return this.http
      .post<any>(this.apiUrl+'api/order/add', orderData, {
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


  edit(orderData: any): Observable<any> {
    console.log(orderData.id);
    return this.http
      .put<any>(`${this.apiUrl}api/order/update/${orderData.id}`, orderData, {
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

  getOrders(): Observable<any> {
    return this.http.get<any>(this.apiUrl+'api/order').pipe(
      catchError((error) => {
        console.error('API Error:', error);
        throw error;
      })
    );
  }

  // Method to fetch customer data (GET request)
  getAll(): Observable<any> {
    return this.http.get<any>(this.apiUrl+'v1/order/get').pipe(
      catchError((error) => {
        console.error('API Error:', error);
        throw error;
      })
    );
  }
}
