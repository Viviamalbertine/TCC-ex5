import { Component, ViewChild, ElementRef } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { ToastController, LoadingController } from 'ionic-angular';
import { LoginSuccessfulPage } from '../login-successful/login-successful';
import { AuthenticationService } from '../../services/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OperationResult } from '../../models/operation-result';

//
//@Classe para a página de Login do aplicativo
//
@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {

  //
  //@Contém referência ao elemento HTML que contém a renderizaçaão do Spinner
  //
  @ViewChild('loadingSpinner') loadingSpinner: ElementRef;

  //
  //@Contém referência ao objeto que representa o formulário de autenticação
  //
  loginForm: FormGroup;

  //
  //@Construtor da página que é invocado quando a página é inserida na pilha do Ionic
  //
  constructor(public navCtrl: NavController,
              public navParams: NavParams,
              private toastCtrl: ToastController,
              private loadingCtrl: LoadingController,
              private formBuilder: FormBuilder,
              private authService:  AuthenticationService) {
                this.initForm();
  }

  //
  //@Método que configura o formulário e seus campos
  //
  initForm() {
    this.loginForm = this.formBuilder.group({
      'email' : this.formBuilder.control('', [Validators.required, Validators.pattern( /[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?/ )]),
      'password' : this.formBuilder.control('', Validators.required),
    });
  }

  //
  //@Método que manipula o evento de submissão dos dados do formulário
  //
  onSubmit() {
    const loadingWidget = this.loadingCtrl.create({ content : this.loadingSpinner.nativeElement.outerHTML });

    //apresenta o spinner, indicando que a aplicação estaá processando a aplicação
    loadingWidget.present();

    //solicita à classe que serviço a autenticação do usuário com base nos dados do formulário
    this.authService.authenticate(this.loginForm.value)
                    .subscribe((result: OperationResult) => {
                                 if(result.success){
                                  this.navCtrl.push(LoginSuccessfulPage);
                                 } else {
                                  this.displayToast(result.message);
                                 }
                               },
                               (error: any) => {
                                 loadingWidget.dismiss();
                                 this.displayToast(error.message, 'middle');
                                },
                               () => { loadingWidget.dismiss(); });
  }

  //
  //@Mostra uma mensagem utilizando um Toast
  //
  private displayToast(message?:string, position:string = 'top', duration:number = 5000) {
    this.toastCtrl.create({ message, position, duration }).present();
  }
}
