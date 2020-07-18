import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from 'src/app/_services/usuario.service';
import { User } from 'src/app/_models/User';

@Component({
  selector: 'app-usuarioEdit',
  templateUrl: './usuarioEdit.component.html',
  styleUrls: ['./usuarioEdit.component.css']
})
export class UsuarioEditComponent implements OnInit {

  constructor( public router: Router
    , public fb: FormBuilder
    , private toastr: ToastrService
    , private usuarioService: UsuarioService) { }


registerForm: FormGroup;
user: User;

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
});
}

}
