import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public url = "https://localhost:5001/api/authentication";

  constructor(private http: HttpClient, private router: Router, private jwtService: JwtHelperService) { }

  register(userData: any) : Observable<any>{
    return this.http.post<any>(`${this.url}/sign-up`, userData)
    .pipe(map(() => {
      this.router.navigate(['/login']);
    }));
  }

  login(userData: any) : Observable<any>{
    console.log(userData);
    return this.http.post<any>(`${this.url}/login`, userData)
    .pipe(map((response : any) => {
      console.log(response);
      if(response?.accessToken){
        localStorage.setItem('token', response.accessToken);
        this.router.navigate(['']);
      }
      this.router.navigate(['/login']);
    }));
  }

  isLoggedIn(){
    const token = localStorage.getItem('token') || "";
    return !this.jwtService.isTokenExpired(token);
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
