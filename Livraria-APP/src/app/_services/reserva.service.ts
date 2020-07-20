import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Reserva } from '../_models/Reserva';
import { environment } from 'src/environments/environment';
import { Emprestimo } from '../_models/Emprestimo';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

constructor(private http: HttpClient) { }
  baseURL = environment.apiUrl + 'api/Values/';

  getAllReservas(): Observable<any> {
    return this.http.get<any>(this.baseURL);
  }

  postReserva(reserva: Reserva) {
    return this.http.post(`${this.baseURL}AdicionarReserva`, reserva);
  }

  postEmprestimo(emprestimo: Emprestimo) {
    return this.http.post(`${this.baseURL}AdicionarEmprestimo`, emprestimo);
  }
}
