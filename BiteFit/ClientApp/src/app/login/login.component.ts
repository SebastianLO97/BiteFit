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
    existe: number = 0;

    Login() {
        this.login = new Login;
        this.login.username = this.formGroup.controls['username'].value;
        this.login.password = this.formGroup.controls['password'].value;
        console.log(this.login);
        this._httpService.post('/api/Login/', this.login).subscribe(existe => {
            this.existe = existe.json() as number;
        });
        if (this.existe == 1) {
            window.location.href = "/home";
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
    }

}
