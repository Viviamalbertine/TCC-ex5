import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/timeout';
import { appParameters } from "../app/app.parameters";
import { Login } from "../models/login";

//
//@Classe de serviço de autenticação.
//
@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) {}

    //
    //@Método que envia uma solicitação para o servidor, enviando os dados de autenticaçaão informados pelo usuário
    //
    authenticate(login: Login): Observable<any> {
        return this.http.post(appParameters.authenticationEndpointUrl, { email : login.email, password : login.password })
                        .timeout(appParameters.requestTimeout)
                        .catch(err => Observable.throw({ success : false, code : -1, message : 'Houve um erro técnico ao tentar realizar a solicitação para o servidor. Por favor, entre em contato com o suporte/administrador da aplicação e reporte o ocorrido.'}));
   }
}
