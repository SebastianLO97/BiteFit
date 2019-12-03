import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Dieta } from './Models/Dieta';

@Component({
    selector: 'app-dieta',
    templateUrl: './dieta.component.html',
    styleUrls: ['./dieta.component.css']
})
export class DietaComponent implements OnInit {

    apiDietas: Dieta;

    dieta: string;

    constructor(private _httpService: Http) { }

    ngOnInit() {
        this._httpService.get('/api/Dieta/GetDieta/1').subscribe(dietas => {
            this.apiDietas = dietas.json() as Dieta;
        });
    }
}
