import { Livro } from "./Livro";

export interface Autor{
  autorId: number;
  livros: Livro[];
}