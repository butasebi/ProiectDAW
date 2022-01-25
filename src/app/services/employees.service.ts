import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  public url = "https://localhost:5001/api/controller/employees";
  constructor(
    private http: HttpClient
  ) { }

  public getEmployees(id): Observable<any>{
    return this.http.get<any>(`${this.url}/byServiceId/${id}`)
  }

  public createEmployee(employee): Observable<any>{
    return this.http.post(`${this.url}/employeeCreate`, employee);
  }

  public updateEmployee(employee): Observable<any>{
    return this.http.post(`${this.url}/employeeUpdate`, employee);
  }

  public deleteEmployee(employee): Observable<any>{
    console.log(employee);
    return this.http.post<any>(`${this.url}/employeeDelete`, employee);
  }
}
