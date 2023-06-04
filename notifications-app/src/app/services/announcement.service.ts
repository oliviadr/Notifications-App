import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Announcement } from '../announcement';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {

  baseUrl="https://localhost:7173/announcements"
 announcements: Announcement[]
 
  constructor (private HttpClient:HttpClient ) { }

  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  serviceCall() {
    console.log("Service was called");
  }

  getAnnouncements(): Observable<Announcement[]>{

    return this.HttpClient.get <Announcement[]>(this.baseUrl,this.httpOptions);
  }
  addAnnouncement(announcement:Announcement)
  {

    return this.HttpClient.post<Announcement>(this.baseUrl  ,
      announcement,this.httpOptions)
    
  }

  deleteAnnouncement(id:string)
  {
    this.HttpClient.delete(this.baseUrl +"/"+id,this.httpOptions,).subscribe(response=>{
      return response;
    })
  }
}
