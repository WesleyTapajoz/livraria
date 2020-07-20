import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReservasComponent } from './reservas/reservas.component';
import { NavComponent } from './nav/nav.component';
import { LivroComponent } from './livro/livro.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';
import { UserComponent } from './user/user.component';
import { TituloComponent } from './_shared/titulo/titulo.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LivroService } from './_services/livro.service';
// import { AuthInterceptor } from './auth/auth.interceptor';
import { EmprestimoComponent } from './emprestimo/emprestimo.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { InstituicaoEnsinoComponent } from './instituicao-ensino/instituicao-ensino.component';
import { NgxMaskModule, IConfig  } from 'ngx-mask';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};
@NgModule({
   declarations: [
      AppComponent,
      ReservasComponent,
      NavComponent,
      LivroComponent,
      DateTimeFormatPipePipe,
      UserComponent,
      TituloComponent,
      LoginComponent,
      RegistrationComponent,
      DashboardComponent,
      EmprestimoComponent,
      UsuarioComponent,
      InstituicaoEnsinoComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      NgxMaskModule.forRoot(options),
      ModalModule.forRoot(),
      ToastrModule.forRoot({
        timeOut: 3000,
        preventDuplicates: true,
        progressBar: true
     }),
    BsDatepickerModule.forRoot(),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TooltipModule.forRoot()
  ],
  providers: [

  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
