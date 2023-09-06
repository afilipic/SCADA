import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Period } from '../models/Period';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {


  constructor(private http : HttpClient) { }
  
  private headers = new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  });

  httpRoot = 'http://localhost:5001/reports/'


  getAlarmPeriod(period : Period) : Observable<any>{
    return this.http.post<any>(this.httpRoot + 'alarms/period', period, {headers: this.headers});

  }

  getAlarmPriority(p : number) : Observable<any>{
    return this.http.get<any>(this.httpRoot + 'alarms/' + p, {headers: this.headers});

  }

  getLastAIValues(): Observable<any>{
    return this.http.get<any>(this.httpRoot + 'AI', {headers: this.headers});

  }

  getLastDIValues(): Observable<any>{
    return this.http.get<any>(this.httpRoot + 'DI', {headers: this.headers});

  }

  getAllValuesByPeriod(period: Period): Observable<any>{
    return this.http.post<any>(this.httpRoot + 'tags/period',period, {headers: this.headers});

  }
  

  getAllValuesByTagId(id: string): Observable<any>{
    return this.http.get<any>(this.httpRoot + 'tags/' + id, {headers: this.headers});

  }


}
