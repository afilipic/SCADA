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
    return this.http.put<any>(this.httpRoot + type +'/' + id + "/" + value, null);
  
  }
  switch(tagId : string, type : string): Observable<any> {
    return this.http.put<any>(this.httpRoot + type + '/switch/' + tagId, null);
  
  }

  deleteTag(tagId : string, type : string): Observable<any> {
    return this.http.delete<any>(this.httpRoot + type + '/' + tagId);
  
  }

//DIGITAL OUTPUT

getAllDO(): Observable<DOTag[]> {
  return this.http.get<DOTag[]>(this.httpRoot + 'DO');
}

addDO(tag : DOTag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'DO', tag);

}




//DIGITAL INPUT

getAllDI(): Observable<DITag[]> {
  return this.http.get<DITag[]>(this.httpRoot + 'DI');
}

addDI(tag : DITag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'DI', tag);

}




//ANALOG OUTPUT

getAllAO(): Observable<AOTag[]> {
  return this.http.get<AOTag[]>(this.httpRoot + 'AO');
}

addAO(tag : AOTag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'AO', tag);

}


//ANALOG INPUT

getAllAI(): Observable<AITag[]> {
  return this.http.get<AITag[]>(this.httpRoot + 'AI');
}

addAI(tag : AITag): Observable<any> {
  return this.http.post<any>(this.httpRoot + 'AI', tag);

}





}
