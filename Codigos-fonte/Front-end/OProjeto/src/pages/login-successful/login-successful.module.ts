import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { LoginSuccessfulPage } from './login-successful';

@NgModule({
  declarations: [
    LoginSuccessfulPage,
  ],
  imports: [
    IonicPageModule.forChild(LoginSuccessfulPage),
  ],
})
export class LoginSuccessfulPageModule {}
