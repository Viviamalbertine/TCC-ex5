import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app.module';

//
//@Ponto de entrada/inicialização da aplicação. É aqui que o módulo da aplicação é carregado.
//
platformBrowserDynamic().bootstrapModule(AppModule);
