import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InstituicaoEnsino } from '../_models/InstituicaoEnsino';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class InstituicaoEnsinoService {

constructor(private http: HttpClient) { }

baseURL = 'https://localhost:44324/api/Values/';

  getAllInstituicoesEnsino(): Observable<InstituicaoEnsino[]> {
    return this.http.get<InstituicaoEnsino[]>(`${this.baseURL}GetInstituicoesEnsino`);
  }

  postInstituicao(model: any) {
    return this.http.post(`${this.baseURL}AdicionarInstituicao`, model);
  }

  instituicaoDisable(model: any) {
    return this.http.put(`${this.baseURL}InstituicaoDisable`, model);
  }
}
