import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginDTO } from '../models/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }
  
  private headers = new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  });

  signIn(user: LoginDTO): Observable<any> {
    return this.http.post<any>(
      'http://localhost:5001/user/login', user, {headers: this.headers} );
  }

  signUp(user: LoginDTO): Observable<any> {
    return this.http.post<any>(
      'http://localhost:5001/user/register', user);
  }


}
