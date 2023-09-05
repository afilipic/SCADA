import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AITag, AOTag, DITag, DOTag } from '../models/Tag';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private http : HttpClient) { }
  
  private headers = new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  });

  httpRoot = 'http://localhost:5001/tag/'


//DIGITAL OUTPUT

getAllDO(): Observable<any> {
  return this.http.get<any>(this.httpRoot + 'DO');
}

addDO(tag : DOTag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'DO', tag);

}

editDO(tag : DOTag): Observable<any> {
  return this.http.put<any>(this.httpRoot + 'DO/' + tag.Id, tag);

}

deleteDO(tagId : number): Observable<any> {
  return this.http.delete<any>(this.httpRoot + 'DO/' + tagId);

}


//DIGITAL INPUT

getAllDI(): Observable<any> {
  return this.http.get<any>(this.httpRoot + 'DI');
}

addDI(tag : DITag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'DI', tag);

}

editDI(tag : DITag): Observable<any> {
  return this.http.put<any>(this.httpRoot + 'DI/' + tag.Id, tag);

}

switchDI(tagId : number): Observable<any> {
  return this.http.put<any>(this.httpRoot + 'DI/switch/' + tagId, null);

}

deleteDI(tagId : number): Observable<any> {
  return this.http.delete<any>(this.httpRoot + 'DI/' + tagId);

}

//ANALOG OUTPUT

getAllAO(): Observable<any> {
  return this.http.get<any>(this.httpRoot + 'AO');
}

addAO(tag : AOTag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'AO', tag);

}

editAO(tag : AOTag): Observable<any> {
  return this.http.put<any>(this.httpRoot + 'AO/' + tag.Id, tag);

}

deleteAO(tagId : number): Observable<any> {
  return this.http.delete<any>(this.httpRoot + 'AO/' + tagId);

}

//ANALOG INPUT

getAllAI(): Observable<any> {
  return this.http.get<any>(this.httpRoot + 'AI');
}

addAI(tag : AITag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'AI', tag);

}

editAI(tag : AITag): Observable<any> {
  return this.http.put<any>(this.httpRoot + 'AI/' + tag.Id, tag);

}

switchAI(tagId : number): Observable<any> {
  return this.http.put<any>(this.httpRoot + 'AI/switch/' + tagId, null);

}

deleteAI(tagId : number): Observable<any> {
  return this.http.delete<any>(this.httpRoot + 'AI/' + tagId);

}


}
