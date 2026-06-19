import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import {
  arithmaticOperationRequest,
  compareRequest,
  convertRequest,
} from '../models/quantaty.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class QuantityService {
  constructor(private http: HttpClient) {}
  private apiUrl = `${environment.apiUrl}/quantity`;

  compare(data: compareRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/compare`, data);
  }

  add(data: arithmaticOperationRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/add`, data);
  }

  sub(data: arithmaticOperationRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/sub`, data);
  }

  div(data: arithmaticOperationRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/div`, data);
  }

  convert(data: convertRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/convert`, data);
  }

  hostory(): Observable<any> {
    return this.http.get(`${this.apiUrl}/history`);
  }

  deleteHistory(): Observable<any> {
    return this.http.delete(`${this.apiUrl}/history`);
  }
}
