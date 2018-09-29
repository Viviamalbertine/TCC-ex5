import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

//
//@Classe para a página de Login efetuado com sucesso
//
@IonicPage()
@Component({
  selector: 'page-login-successful',
  templateUrl: 'login-successful.html',
})
export class LoginSuccessfulPage {

  constructor(public navCtrl: NavController, public navParams: NavParams) {
  }

}
