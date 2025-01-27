// product.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = 'https://localhost:7181/'; // API URL

  constructor(private http: HttpClient) {}

  // Method to register a customer (POST request)
  addProduct(productData: any): Observable<any> {
    console.log(productData);
    return this.http
      .post<any>(this.apiUrl+'api/product/add', productData, {
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

  editProduct(productData: any): Observable<any> {
    console.log(productData);
    return this.http
      .put<any>(`${this.apiUrl}api/product/update/${productData.id}`, productData, {
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

  // Method to fetch product data (GET request)
  getAll(): Observable<any> {
    return this.http.get<any>(this.apiUrl+'api/product').pipe(
      catchError((error) => {
        console.error('API Error:', error);
        throw error;
      })
    );
  }

  removeProduct(productData: any): Observable<any> {
    console.log(productData);
    return this.http
      .post<any>(this.apiUrl+'v1/product/delete', productData, {
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
