import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Http } from '@angular/http';
import { Login } from './Models/Login';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    constructor(private formBuilder: FormBuilder, private _httpService: Http) { }

    formGroup: FormGroup;

    login: Login;
    apiUsers: Login[];
    existe: number;

    Login() {
        this.login = new Login;
        this.login.username = this.formGroup.controls['username'].value;
        this.login.password = this.formGroup.controls['password'].value;
        console.log(this.login);
        console.log(this.apiUsers);
        this._httpService.post('/api/Login/', this.login).subscribe(existe => {
            this.existe = existe.json() as number;
        });
        if (this.existe == 1) {
            console.log("Works");
        } else {
            console.log("No Works");
        }
    }

    Register() {
        window.location.href ="/register-usuario";
    }

    ngOnInit() {
        this.formGroup = this.formBuilder.group({
            username: [''],
            password: [''],
        });
        //this._httpService.get('/api/Login').subscribe(users => {
        //    this.apiUsers = users.json() as Login[];
        //});
    }

}
