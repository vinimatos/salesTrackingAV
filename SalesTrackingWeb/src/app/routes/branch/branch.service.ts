// product.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class BranchService {
  private apiUrl = 'https://localhost:7024/'; // API URL

  constructor(private http: HttpClient) {}

  // Method to register a customer (POST request)
  addBranch(branchData: any): Observable<any> {
    console.log(branchData);
    return this.http
      .post<any>(this.apiUrl+'v1/branch/add', branchData, {
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

  editBranch(branchData: any): Observable<any> {
    console.log(branchData);
    return this.http
      .post<any>(this.apiUrl+'v1/branch/update', branchData, {
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


  removeBranch(branchData: any): Observable<any> {
    console.log(branchData);
    return this.http
      .post<any>(this.apiUrl+'v1/branch/delete', branchData, {
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
    return this.http.get<any>(this.apiUrl+'v1/branch/get').pipe(
      catchError((error) => {
        console.error('API Error:', error);
        throw error;
      })
    );
  }
}
