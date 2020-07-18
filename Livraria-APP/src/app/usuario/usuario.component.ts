import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../_models/User';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from '../_services/usuario.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  constructor( public router: Router
    , public fb: FormBuilder
    , private toastr: ToastrService
    , private modalService: BsModalService
    , private usuarioService: UsuarioService) { }

    titulo = 'Usuários';
    registerForm: FormGroup;
    user: User;
    users: User[];
    modalRef: BsModalRef;


    ngOnInit() {
      this.validation();
      this.getAllUser();
    }

    getAllUser() {
      this.usuarioService.getAllUser().subscribe(
        (_user: User[]) => {
          this.users = _user;
          console.log(_user);
        }, error => {
          this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
        });
      }


      validation() {
        this.registerForm = this.fb.group({
          fullName: ['', Validators.required],
          email: ['', [Validators.required, Validators.email]],
          userName: ['', Validators.required],
          cpf:  ['', Validators.required],
          endereco: [''],
          id: [this.user],
          passwords: this.fb.group({
            password: ['', [Validators.required, Validators.minLength(4)]],
            confirmPassword: ['', Validators.required]
          }, { validator: this.compararSenhas })
        });
      }

      compararSenhas(fb: FormGroup) {
        const confirmSenhaCtrl = fb.get('confirmPassword');
        if (confirmSenhaCtrl.errors == null || 'mismatch' in confirmSenhaCtrl.errors) {
          if (fb.get('password').value !== confirmSenhaCtrl.value) {
            confirmSenhaCtrl.setErrors({ mismatch: true });
          } else {
            confirmSenhaCtrl.setErrors(null);
          }
        }
      }

      openModal(template: TemplateRef<any>, user: any){
        this.user = Object.assign({}, user);
        this.registerForm.patchValue(this.user);
        this.modalRef = this.modalService.show(template);
      }


  userEdit() {
    if (this.registerForm.valid) {
      this.user = Object.assign(
        { password: this.registerForm.get('passwords.password').value },
        this.registerForm.value);
      this.usuarioService.userEdit(this.user).subscribe(
        () => {
          this.getAllUser();
          this.modalRef.hide();
          this.toastr.success('Salvo com sucesso');
        }, error => {
          this.toastr.error(`Erro!: ${error.error}`);
        }
      );
    }
  }

  userDisable() {
      this.usuarioService.userDisable(this.user).subscribe(
        () => {
           this.getAllUser();
          this.modalRef.hide();
          this.toastr.success('Salvo com sucesso');
        }, error => {
          this.toastr.error(`Erro!: ${error.error}`);
        }
      );
  }
}
