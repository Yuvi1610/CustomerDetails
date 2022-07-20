import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const API_URL = 'https://localhost:44318/api/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  addCustomer(customer: any): Observable<any> {
    return this.http.post(API_URL + 'Customer/AddCustomer', customer, httpOptions);
  }

  getCustomerList(): Observable<any> {
    return this.http.get(API_URL + 'Customer/GetCustomerList', httpOptions);
  }
}
