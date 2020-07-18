import { Reserva } from "./Reserva";

export interface User{
  id: number;
  userName: string;
  email: string;
  password: string;
  fullName: string;
  endereco: string;
  cpf: string;
  telefone: string;
  ativo: boolean;
}
