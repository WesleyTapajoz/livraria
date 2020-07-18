import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ReservaService } from '../_services/reserva.service';
import { User } from '../_models/User';
import { ToastrService } from 'ngx-toastr';
import { Livro } from '../_models/Livro';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { LivroService } from '../_services/livro.service';

@Component({
  selector: 'app-reservas',
  templateUrl: './reservas.component.html',
  styleUrls: ['./reservas.component.css']
})
export class ReservasComponent implements OnInit {

  titulo = 'Reservas';
  filtroLista;
  reservas: User[];
  reserva: User;
  livro: Livro;
  livros: Livro[];
  modalRef: BsModalRef;
  registerForm: FormGroup;

  constructor(private fb: FormBuilder,
              private reservaService: ReservaService,
              private toastr: ToastrService,
              private livroService: LivroService ,
              private modalService: BsModalService) { }

  ngOnInit () {
    this.getLivros();
  }

  // getReservas() {
  //   this.reservaService.getAllReservas().subscribe(
  //     (_reservas: any) => {
  //      this.reservas = _reservas;

  //       console.log(_reservas);
  //     }, error => {
  //       this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
  //     });
  // }

  getLivros() {
    this.livroService.getAllLivros().subscribe(
      (_livros: Livro[]) => {
       this.livros = _livros;

        console.log(_livros);
      }, error => {
        this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
      });
  }

  reservar() {
    this.livroService.getAllLivros().subscribe(
      (_livros: Livro[]) => {
       this.livros = _livros;

        console.log(_livros);
      }, error => {
        this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
      });
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }
}
