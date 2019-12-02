import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Http } from '@angular/http';
import { Pais } from './Models/Pais';
import { Estado } from './Models/Estado';
import { Register } from './Models/Register';

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
    register: Register;

    Registar() {
        this.register = new Register;
        this.register.email = this.formGroup.controls['email'].value;
        this.register.username = this.formGroup.controls['username'].value;
        this.register.password = this.formGroup.controls['password'].value;
        this.register.nombre = this.formGroup.controls['nombre'].value;
        this.register.apellidoPat = this.formGroup.controls['apellidoPaterno'].value;
        this.register.apellidoMat = this.formGroup.controls['apellidoMaterno'].value;
        this.register.genero = this.formGroup.controls['genero'].value;
        this.register.fechaNacimiento = this.formGroup.controls['fechaNacimiento'].value;
        this.register.pais = this.apiPaises.find(x => x.id == this.formGroup.controls['pais'].value).nombre;
        this.register.estado = this.apiEstados.find(x => x.id == this.formGroup.controls['estado'].value).nombre;
        this.register.municipio = this.formGroup.controls['municipio'].value;
        this.register.fraccionamiento = this.formGroup.controls['fraccionamiento'].value;
        this.register.calle = this.formGroup.controls['calle'].value;
        this.register.numeroExterior = this.formGroup.controls['numeroExterior'].value;
        if (this.formGroup.controls['numeroInterior'].value == "") {
            this.register.numeroInterior = 0;
        } else {
            this.register.numeroInterior = this.formGroup.controls['numeroInterior'].value;
        }
        this.register.cp = this.formGroup.controls['cp'].value;
        console.log(this.register);
        this._httpService.post('/api/RegisterUser/', this.register).subscribe();
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
