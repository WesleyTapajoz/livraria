import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Livro } from '../_models/Livro';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LivroService {

  constructor(private http: HttpClient) { }
  baseURL = 'https://localhost:44324/api/Values';
  baseURLLogin = 'https://localhost:44324/api/user/';


  jwtHelper = new JwtHelperService();
  decodedToken: any;


  login(model: any) {
    return this.http
      .post(`${this.baseURLLogin}login`, model).pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            sessionStorage.setItem('username', this.decodedToken.unique_name);
          }
        })
      );
  }


  register(model: any) {
    return this.http.post(`${this.baseURLLogin}register`, model);
  }

  getAllLivros(): Observable<Livro[]> {
    return this.http.get<Livro[]>(`${this.baseURL}/GetLivros`);
  }
}
