// customer.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  private apiUrl = 'https://localhost:7181/'; // API URL

  constructor(private http: HttpClient) {}

  // Method to register a customer (POST request)
  addCustomer(customerData: any): Observable<any> {
    console.log(customerData);
    return this.http
      .post<any>(this.apiUrl+'api/customer/add', customerData, {
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

  // Method to fetch customer data (GET request)
  getAll(): Observable<any> {
    return this.http.get<any>(this.apiUrl+'api/customer').pipe(
      catchError((error) => {
        console.error('API Error:', error);
        throw error;
      })
    );
  }

  editCustomer(customerData: any): Observable<any> {
    return this.http
      .put<any>(`${this.apiUrl}api/customer/update/${customerData.id}`, customerData, {
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
  

  
  removeCustomer(customerData: any): Observable<any> {
    console.log(customerData);
    return this.http
      .post<any>(this.apiUrl+'v1/customer/delete', customerData, {
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
