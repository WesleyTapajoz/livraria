import { Component, OnInit, TemplateRef } from '@angular/core';
import { Livro } from '../_models/Livro';
import { LivroService } from '../_services/livro.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Reserva } from '../_models/Reserva';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ReservaService } from '../_services/reserva.service';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})
export class LivroComponent implements OnInit {
  locale = 'pt-br';
  constructor(
              private fb: FormBuilder,
              private livroService: LivroService,
              private toastr: ToastrService,
              private modalService: BsModalService,
              private localeService: BsLocaleService,
              private reservaService: ReservaService
              ) {
                this.localeService.use(this.locale);
              }

  livro: Livro;
  livros: Livro[];
  modalRef: BsModalRef;
  registerForm: FormGroup;
  dataReserva: Date;
  reserva = new Reserva();
  titulo = 'Livros';
  dataAtual: string;

  ngOnInit() {
    this.validation();
    this.getLivros();
  }


  validation() {
    this.registerForm = this.fb.group({
      dataReserva: ['', Validators.required],
      livroId: [''],
    });
  }


  getLivros() {
    this.livroService.getAllLivros().subscribe(
      (_livros: Livro[]) => {
       this.livros = _livros;

        console.log(_livros);
      }, error => {
        this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
      });
  }

  reservar(livro) {

    this.reserva.livroId = this.livro.livroId;
    this.reserva.dataReserva = this.dataReserva;
    this.reserva.usuarioId = 1;
    this.registerForm.patchValue(this.reserva);

    console.log(this.reserva);

    this.reservaService.postReserva(this.reserva).subscribe(
      (novaReserva: Reserva) => {
        this.modalRef.hide();
        this.getLivros();
        this.toastr.success('Inserido com Sucesso!');
      }, error => {
        this.toastr.error(`Erro ao Inserir: ${error}`);
      }
    );
  }

  openModal(template: TemplateRef<any>, livro: any){
    this.livro = Object.assign({}, livro);


    console.log(this.livro.livroId);

    this.registerForm.patchValue(this.livro);
    this.modalRef = this.modalService.show(template);
  }

}
