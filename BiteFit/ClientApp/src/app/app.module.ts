import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { RegisterUsuarioComponent } from './register-usuario/register-usuario.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { InfoComponent } from './info/info.component';
import { HomeComponent } from './home/home.component';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        RegisterUsuarioComponent,
        HomeComponent,
        InfoComponent,
        
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        ReactiveFormsModule,
        HttpModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: '', component: LoginComponent, pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: 'register-usuario', component: RegisterUsuarioComponent },
            { path: 'Home', component: HomeComponent },
            { path: 'Info', component: InfoComponent },
        ])
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
