import { Bruger } from './bruger';
import { Opskrift } from './opskrift';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { catchError } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  opskriftUrl = "https://localhost:44337/api/Opskrifts";
  opskriftUrl2 = "https://localhost:44337/api/Opskrifts/:"
  BrugerUrl = "https://localhost:44337/api/Brugers";

  

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private http: HttpClient) { }

  getOpskrift(): Observable<Opskrift> {
    return this.http.get<Opskrift>(this.opskriftUrl)
  }

  getOpskriftById(id): Observable<any> {
    return this.http.get(`${this.opskriftUrl2}/${id}`)
  }

  createOpskrift(data): Observable<Opskrift> {
    return this.http.post<Opskrift>(this.opskriftUrl, JSON.stringify(data), this.httpOptions)
  }
  
  createBruger(data): Observable<Bruger> {
    return this.http.post<Bruger>(this.BrugerUrl, JSON.stringify(data), this.httpOptions)
  }

  deleteAllOpskrift(): Observable<any> {
    return this.http.delete(this.opskriftUrl, this.httpOptions)
  }
}
