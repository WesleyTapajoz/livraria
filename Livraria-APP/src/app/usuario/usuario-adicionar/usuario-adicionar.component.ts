import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from 'src/app/_models/User';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/_services/usuario.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-usuario-adicionar',
  templateUrl: './usuario-adicionar.component.html',
  styleUrls: ['./usuario-adicionar.component.css']
})
export class UsuarioAdicionarComponent implements OnInit {

  registerForm: FormGroup;
  user: User;
  users: User[];
  modalRef: BsModalRef;

  constructor( public router: Router
    , public fb: FormBuilder
    , private toastr: ToastrService
    , private usuarioService: UsuarioService) {
    }

    ngOnInit() {
      this.validation();
    }

    validation() {
      this.registerForm = this.fb.group({
        fullName: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        userName: ['', Validators.required],
        cpf:  ['', Validators.required],
        endereco: [''],
        telefone: [''],
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
  getAllUser() {
    this.usuarioService.getAllUser().subscribe(
      (_user: User[]) => {
        this.users = _user;
        console.log(_user);
      }, error => {
        this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
      });
    }
  cadastrarUsuario() {
    if (this.registerForm.valid) {
      this.user = Object.assign(
        { password: this.registerForm.get('passwords.password').value },
        this.registerForm.value);
      this.usuarioService.register(this.user).subscribe(
        () => {
          this.modalRef.hide();
          this.getAllUser();
          this.toastr.success('Cadastro Realizado');
        }, error => {
          const erro = error.error;
          erro.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Cadastro Duplicado!');
                break;
              default:
                this.toastr.error(`Erro no Cadatro! CODE: ${element.code}`);
                break;
            }
          });
        }

      );
    }
  }

}
