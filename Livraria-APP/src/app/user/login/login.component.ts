import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/_services/auth.service';
import { LivroService } from 'src/app/_services/livro.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  titulo = 'Login';
  model: any = {};

  constructor(private authService: AuthService,
      private livroService: LivroService
    , public router: Router
    , private toastr: ToastrService) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      this.router.navigate(['/dashboard']);
    }
  }

  login() {

    console.log(this.model);
    // this.getLivros() ;
    this.livroService.login(this.model)
      .subscribe(
        () => {
          this.router.navigate(['/dashboard']);
          this.toastr.success('Logado com Sucesso');
        },
        error => {
          this.toastr.error('Falha ao tentar Logar');
          console.log(error);
        }
      );
  }
  // getLivros() {
  //   this.loginService.login(this.model).subscribe(
  //     (_livros: any[]) => {

  //       console.log(_livros);
  //     }, error => {
  //       this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
  //     });
  // }

}
