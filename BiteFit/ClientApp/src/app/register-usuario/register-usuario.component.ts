import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Http } from '@angular/http';
import { Pais } from './Models/Pais';
import { Estado } from './Models/Estado';

@Component({
    selector: 'app-register-usuario',
    templateUrl: './register-usuario.component.html',
    styleUrls: ['./register-usuario.component.css']
})
export class RegisterUsuarioComponent implements OnInit {

    constructor(private formBuilder: FormBuilder, private _httpService: Http) { }

    formGroup: FormGroup;

    apiPaises: Pais[];
    apiEstados: Estado[];

    Registar() {
        console.log(this.formGroup.controls['email'].value);
        console.log(this.formGroup.controls['genero'].value);
    }
    
    ngOnInit() {
        this.formGroup = this.formBuilder.group({
            email: [''],
            username: [''],
            password: [''],
            nombre: [''],
            apellidoPaterno: [''],
            apellidoMaterno: [''],
            genero: [''],
            fechaNacimiento: [''],
            pais: [''],
            estado: [''],
            municipio: [''],
            fraccionamiento: [''],
            calle: [''],
            numeroExterior: [''],
            numeroInterior: [''],
            cp: [''],
        });
        this._httpService.get('api/RegisterUser/Pais').subscribe(paises => {
            this.apiPaises = paises.json() as Pais[];
        });
        this._httpService.get('api/RegisterUser/Estado').subscribe(estados => {
            this.apiEstados = estados.json() as Estado[];
        });
    }

}
