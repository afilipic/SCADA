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

  httpRoot = 'http://localhost:5001/tags/'



  editTag(id : string, value: number, type : string): Observable<any> {
    return this.http.put<any>(this.httpRoot + type +'/' + id + "/" + value, null, {headers: this.headers});
  
  }
  switch(tagId : string, type : string): Observable<any> {
    return this.http.put<any>(this.httpRoot + type + '/switch/' + tagId, null, {headers: this.headers});
  
  }

  deleteTag(tagId : string, type : string): Observable<any> {
    return this.http.delete<any>(this.httpRoot + type + '/' + tagId, {headers: this.headers});
  
  }

//DIGITAL OUTPUT

getAllDO(): Observable<DOTag[]> {
  return this.http.get<DOTag[]>(this.httpRoot + 'DO', {headers: this.headers});
}

addDO(tag : DOTag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'DO', tag,  {headers: this.headers});

}




//DIGITAL INPUT

getAllDI(): Observable<DITag[]> {
  return this.http.get<DITag[]>(this.httpRoot + 'DI', {headers: this.headers});
}

addDI(tag : DITag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'DI', tag, {headers: this.headers});

}




//ANALOG OUTPUT

getAllAO(): Observable<AOTag[]> {
  return this.http.get<AOTag[]>(this.httpRoot + 'AO', {headers: this.headers});
}

addAO(tag : AOTag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'AO', tag, {headers: this.headers});

}


//ANALOG INPUT

getAllAI(): Observable<AITag[]> {
  return this.http.get<AITag[]>(this.httpRoot + 'AI', {headers: this.headers});
}

addAI(tag : AITag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'AI', tag, {headers: this.headers});

}





}
