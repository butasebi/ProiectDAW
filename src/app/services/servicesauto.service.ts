import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesautoService {
  public url = 'https://localhost:5001/api/controller'
  constructor(
    private http: HttpClient
  ) { }

  public getServices(): Observable<any>{
    //console.log(`${this.url}/servicesauto`);
    return this.http.get<any>(`${this.url}/servicesauto`);
  }

  public getServiceById(id): Observable<any>{
    // console.log('${this.url}/byId/${id}');
    // console.log(this.url + '/servicesauto/byId/' + id);
    return this.http.get<any>(this.url + '/servicesauto/byId/' + id);
  }

  public createServiceAuto(serviceauto): Observable<any>{
    return this.http.post(`${this.url}/serviceCreate`, serviceauto);
  }

  public updateServiceAuto(serviceauto): Observable<any>{
    return this.http.post(`${this.url}/serviceUpdate`, serviceauto);
  }

  public deleteServiceAuto(serviceauto): Observable<any>{
    console.log(serviceauto);
    return this.http.post<any>(`${this.url}/serviceDelete`, serviceauto);
  }
}
