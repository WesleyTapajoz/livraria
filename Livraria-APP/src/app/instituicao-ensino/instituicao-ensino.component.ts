import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { InstituicaoEnsinoService } from '../_services/instituicaoEnsino.service';
import { InstituicaoEnsino } from '../_models/InstituicaoEnsino';


@Component({
  selector: 'app-instituicao-ensino',
  templateUrl: './instituicao-ensino.component.html',
  styleUrls: ['./instituicao-ensino.component.css']
})
export class InstituicaoEnsinoComponent implements OnInit {

  constructor( public router: Router
    , public fb: FormBuilder
    , private toastr: ToastrService
    , private modalService: BsModalService
    , private instituicaoEnsinoService: InstituicaoEnsinoService) { }

    instituicaoEnsino: InstituicaoEnsino;
    instituicoesEnsino: InstituicaoEnsino[];
    titulo =  'Instituições de Ensino'
    modalRef: BsModalRef;
    registerForm: FormGroup;

    ngOnInit() {
      this.getAllInstituicoesEnsino();
      this.validation();
    }

    validation() {
      this.registerForm = this.fb.group({
        nome: ['', Validators.required],
        endereco: ['', [Validators.required]],
        cnpj: ['', Validators.required],
        telefone:  ['', Validators.required]
      });
    }


    getAllInstituicoesEnsino() {
      this.instituicaoEnsinoService.getAllInstituicoesEnsino().subscribe(
        (_instituicoesEnsino: InstituicaoEnsino[]) => {
          this.instituicoesEnsino = _instituicoesEnsino;
        }, error => {
          this.toastr.error(`Erro ao tentar Carregar: ${error}`);
        });
      }

      novaInstituicao(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template);
      }

      novoEvento(template: any) {
        this.openModal(template, new InstituicaoEnsino() );
      }

      openModal(template: TemplateRef<any>, instituicaoEnsino: any){
        this.instituicaoEnsino = Object.assign({}, instituicaoEnsino);
        this.registerForm.patchValue(this.instituicaoEnsino);
        this.modalRef = this.modalService.show(template);
      }
      salvar(){
        console.log(this.registerForm);
        this.instituicaoEnsino = Object.assign(this.registerForm.value);
        console.log(this.instituicaoEnsino);
        this.instituicaoEnsinoService.postInstituicao(this.instituicaoEnsino).subscribe(
          (novaInstituicao: InstituicaoEnsino) => {
            this.modalRef.hide();
            this.getAllInstituicoesEnsino();
            this.toastr.success('Inserido com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Inserir: ${error}`);
          }
          );
        }


    instituicaoDisable() {
      this.instituicaoEnsinoService.instituicaoDisable(this.instituicaoEnsino).subscribe(
        () => {
          this.getAllInstituicoesEnsino();
          this.modalRef.hide();
          this.toastr.success('Salvo com sucesso');
        }, error => {
          this.toastr.error(`Erro!: ${error.error}`);
        }
      );
  }

}
