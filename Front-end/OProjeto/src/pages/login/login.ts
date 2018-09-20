import { Component, ViewChild, ElementRef } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { ToastController, LoadingController } from 'ionic-angular';
import { LoginSuccessfulPage } from '../login-successful/login-successful';
import { AuthenticationService } from '../../services/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OperationResult } from '../../models/operation-result';

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {

  @ViewChild('loadingSpinner') loadingSpinner: ElementRef;
  loginForm: FormGroup;

  constructor(public navCtrl: NavController,
              public navParams: NavParams,
              private toastCtrl: ToastController,
              private loadingCtrl: LoadingController,
              private formBuilder: FormBuilder,
              private authService:  AuthenticationService) {
                this.initForm();
  }

  initForm() {
    this.loginForm = this.formBuilder.group({
      'email' : this.formBuilder.control('', [Validators.required, Validators.pattern( /[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?/ )]),
      'password' : this.formBuilder.control('', Validators.required),
    });
  }

  onSubmit() {
    const loadingWidget = this.loadingCtrl.create({ content : this.loadingSpinner.nativeElement.outerHTML });
    loadingWidget.present();

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

  private displayToast(message?:string, position:string = 'top', duration:number = 5000) {
    this.toastCtrl.create({ message, position, duration }).present();
  }
}
