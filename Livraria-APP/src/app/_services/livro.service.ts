import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Livro } from '../_models/Livro';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LivroService {

  constructor(private http: HttpClient) { }
  baseURL = environment.apiUrl + 'api/Values/';
  baseURLLogin =  environment.apiUrl + 'api/user/';


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
            sessionStorage.setItem('nameid', this.decodedToken.nameid);
          }
        })
      );
  }


  register(model: any) {
    return this.http.post(`${this.baseURLLogin}register`, model);
  }

  getAllLivros(): Observable<Livro[]> {
    return this.http.get<Livro[]>(`${this.baseURL}GetLivros`);
  }

  postUpload(file: File, name: string) {
    const fileToUplaod = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUplaod, name);

    return this.http.post(`${this.baseURL}upload`, formData);
  }

  postLivro(model: any) {
    return this.http.post(`${this.baseURL}AdicionarLivro`, model);
  }

  putLivro(model: any) {
    return this.http.put(`${this.baseURL}AlterarLivro`, model);
  }

  livroDisable(model: any) {
    return this.http.put(`${this.baseURL}LivroDisable`, model);
  }

}
