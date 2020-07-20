import { Component, OnInit, TemplateRef } from '@angular/core';
import { Livro } from '../_models/Livro';
import { LivroService } from '../_services/livro.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators, FormControlName, FormControl } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Reserva } from '../_models/Reserva';
import { Emprestimo } from '../_models/Emprestimo';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ReservaService } from '../_services/reserva.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})
export class LivroComponent implements OnInit {
  locale = 'pt-br';


  dateRange: string;
  minDate: Date;
  maxDate: Date;

  constructor(
    private fb: FormBuilder,
    private livroService: LivroService,
    private toastr: ToastrService,
    private modalService: BsModalService,
    private localeService: BsLocaleService,
    private reservaService: ReservaService
    ) {
      this.localeService.use(this.locale);
      this.minDate = new Date();
      this.maxDate = new Date();
      this.minDate.setDate(this.minDate.getDate() - 1);
      this.maxDate.setDate(this.maxDate.getDate() + 30);
    }

    livro: Livro;
    livros: Livro[];
    modalRef: BsModalRef;
    registerForm: FormGroup;

    file: File;
    fileNameToUpdate: string;
    modoSalvar = 'post';
    dataReserva: string;

    emprestimo = new Emprestimo();

    reserva = new Reserva();
    titulo = 'Livros';
    dataAtual: string;
    tituloLivro = '';
    imagemLargura = 50;
    imagemMargem = 2;
    mostrarImagem = false;
    url = environment.apiUrl + '/img/';
    retorno: any;

    ngOnInit() {
      this.validation();
      this.getLivros();
    }

    validationReserva(reserva: any): FormGroup {
      return this.fb.group({
        dataReserva: [this.reserva.dataReserva, Validators.required],
      });
    }

    changeDate(event){
      console.log(event);
      this.validationReserva(event);
    }

    changeRange($event){
      this.validationEmprestimo();
    }

    validationEmprestimo(): FormGroup {
      return this.fb.group({
        dateRange: ['', Validators.required],
      });
    }

    validation() {
      this.registerForm = this.fb.group({
        livroId: [],
        titulo: ['', Validators.required],
        genero: ['', Validators.required],
        autor: ['', Validators.required],
        sinopse: ['', Validators.required],
        imagemURL: [''],
        dataReserva: [''],
        dateRange: ['']
      });
    }
    alternarImagem() {
      this.mostrarImagem = !this.mostrarImagem;
    }

    getLivros() {
      this.dataAtual = new Date().getMilliseconds().toString();
      this.livroService.getAllLivros().subscribe(
        (_livros: Livro[]) => {
          this.livros = _livros;

          console.log(_livros);
        }, error => {
          this.toastr.error(`Erro ao tentar Carregar: ${error}`);
        });
      }

      reservar() {
        this.reserva.livroId = this.livro.livroId;
        this.reserva.dataReserva = this.dataReserva;
        this.reserva.id = sessionStorage.getItem('nameid');
        this.registerForm.patchValue(this.reserva);
        console.log(this.reserva);

        this.reservaService.postReserva(this.reserva).subscribe(
          (novaReserva: Reserva) => {
            this.modalRef.hide();
            this.getLivros();
            this.toastr.success('Sucesso!');
          }, error => {
            this.toastr.error(`Erro: ${error}`);
          }
          );
        }

        emprestar() {
          console.log(this.dateRange);
          if (this.dateRange === undefined){
            this.toastr.error(`Erro`);
          }else{

            this.emprestimo.datInicio = this.dateRange[0];
            this.emprestimo.dataFim = this.dateRange[1];
            this.emprestimo.id = sessionStorage.getItem('nameid');
            this.emprestimo.livroId = this.livro.livroId;

            this.reservaService.postEmprestimo(this.emprestimo).subscribe(
              (novaEmprestimo: Emprestimo) => {
                this.retorno = novaEmprestimo;
                this.modalRef.hide();
                this.getLivros();
                this.toastr.success('Sucesso!');
              }, response => {
                this.toastr.error(`${response.error}`);
              }
              );
            }
          }


          novoModal(template: TemplateRef<any>){
            this.tituloLivro =  'Cadastrar Livro';
            this.modoSalvar = 'post';
            this.openModal(template, new Livro());
          }

          editarModal(template: TemplateRef<any>, livro: Livro){
            this.tituloLivro =  livro.titulo;
            this.modoSalvar = 'put';
            this.livro = Object.assign({}, livro);
            this.fileNameToUpdate = livro.imagemURL.toString();
            this.livro.imagemURL = '';
            this.openModal(template, this.livro);
          }

          reservarModal(template: TemplateRef<any>, livro: Livro){

            this.openModal(template, livro);
          }

          emprestimoModal(template: TemplateRef<any>, livro: Livro){
            this.openModal(template, livro);
          }

          openModal(template: TemplateRef<any>, livro: Livro){
            this.livro = Object.assign({}, livro);
            this.registerForm.patchValue(livro);
            this.modalRef = this.modalService.show(template);
          }

          disableModal(template: TemplateRef<any>, livro: Livro){
            this.openModal(template, livro);
          }

          onFileChange(event) {
            if (event.target.files && event.target.files.length) {
              this.file = event.target.files;
            }
          }

          uploadImagem() {
            if (this.modoSalvar === 'post') {
              const nomeArquivo = this.livro.imagemURL.split('\\', 3);
              this.livro.imagemURL = nomeArquivo[2];

              this.livroService.postUpload(this.file, nomeArquivo[2])
              .subscribe(
                () => {
                  this.dataAtual = new Date().getMilliseconds().toString();
                }
                );
              } else {
                this.livro.imagemURL = this.fileNameToUpdate;
                this.livroService.postUpload(this.file, this.fileNameToUpdate)
                .subscribe(
                  () => {
                    this.dataAtual = new Date().getMilliseconds().toString();
                  }
                  );
                }
              }


              salvarAlteracao(template: any) {
                if (this.registerForm.valid) {
                  if (this.modoSalvar === 'post') {
                    this.livro = Object.assign({}, this.registerForm.value);

                    this.uploadImagem();

                    this.livroService.postLivro(this.livro).subscribe(
                      (novoLivro: Livro) => {
                        this.modalRef.hide();
                        this.getLivros();
                        this.toastr.success('Sucesso!');
                      }, error => {
                        this.toastr.error(`Erro: ${error}`);
                      }
                      );
                    } else {
                      this.livro = Object.assign({ id: this.livro.livroId }, this.registerForm.value);
                      this.uploadImagem();

                      this.livroService.putLivro(this.livro).subscribe(
                        () => {
                          this.modalRef.hide();
                          this.getLivros();
                          this.toastr.success('Sucesso!');
                        }, error => {
                          this.toastr.error(`Erro: ${error}`);
                        }
                        );
                      }
                    }
                  }

                  livroDisable() {
                    this.livroService.livroDisable(this.livro).subscribe(
                      (novoLivro: Livro) => {
                        this.getLivros();
                        this.modalRef.hide();
                        this.toastr.success('Sucesso!');
                      }, error => {
                        this.toastr.error(`Erro!: ${error.error}`);
                      }
                      );
                    }


                  }
