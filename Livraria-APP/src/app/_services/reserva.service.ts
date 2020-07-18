import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Reserva } from '../_models/Reserva';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

constructor(private http: HttpClient) { }
  baseURL = 'https://localhost:44324/api/Values';

  getAllReservas(): Observable<any> {
    return this.http.get<any>(this.baseURL);
  }

  postReserva(reserva: any) {
    return this.http.post(`${this.baseURL}/AdicionarReserva`, reserva);
  }
}
