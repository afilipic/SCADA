import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AITag, AOTag, DITag, DOTag } from '../models/Tag';
import { Observable } from 'rxjs';
import { HubConnection} from '@microsoft/signalr'
import { HubConnectionBuilder} from '@microsoft/signalr'
import { HomeComponent } from '../home/home.component';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  private tagConnection? : HubConnection;
  private alarmConnection? : HubConnection;

  constructor(private http : HttpClient) { }
  
  private headers = new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  });

  httpRoot = 'http://localhost:5001/tags/'


  startConnection(){
    this.tagConnection = new HubConnectionBuilder()
    .withUrl('http://localhost:5001/tag', {
      skipNegotiation: true,
      transport : signalR.HttpTransportType.WebSockets
    }).withAutomaticReconnect().build()


    this.tagConnection.start().then(() =>{
      console.log("Tag connection started")
    }).catch(err => console.log ("Error: " + err))


    this.alarmConnection = new HubConnectionBuilder()
    .withUrl('http://localhost:5001/alarms', {
      skipNegotiation: true,
      transport : signalR.HttpTransportType.WebSockets
    }).withAutomaticReconnect().build()


    this.alarmConnection.start().then(() =>{
      console.log("Alarm connection started")
    }).catch(err => console.log ("Error: " + err))





  }

  stopConnection(){
    this.tagConnection?.stop().catch(error => console.log(error));
  }

  addReceiveTagListener(callback: (message: string) => void) {
    this.tagConnection?.on("ReceiveTag", (message: string) => {
      callback(message);
    });
  }

  addReceiveAlarmListener(callback: (message: any) => void) {
    this.alarmConnection?.on("ReceiveAlarm", (message: any) => {
      callback(message);
    });
  }



  editTag(id : string, value: number, type : string): Observable<String> {
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
