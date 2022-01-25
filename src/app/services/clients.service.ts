import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  public url = "https://localhost:5001/api/controller/clients";
  constructor(
    private http: HttpClient
  ) { }

  public getClients(id): Observable<any>{
    return this.http.get<any>(`${this.url}/byServiceId/${id}`)
  }
}
