import { User } from './User';

export class Emprestimo
{
  emprestimoId: number;
  datInicio: string;
  dataFim: string;
  dataEntrega: string;
  id: string;
  user: User;
  livroId: number;
}
