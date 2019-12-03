import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'app-info',
    templateUrl: './info.component.html',
    styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

    constructor(private formBuilder: FormBuilder, private _httpService: Http) { }

    formGroup: FormGroup;

    metaPost: number;
    meta: number;

    ObtenerDieta() {
        this.meta = this.formGroup.controls['metas'].value;
        if (this.meta == 1) {
            this.metaPost = 1;
        } else if (this.meta == 2) {
            this.metaPost = 1;
        } else if (this.meta == 3) {
            this.metaPost = 19;
        } else if (this.meta == 4) {
            this.metaPost = 2;
        }
        console.log(this.meta);
        console.log(this.metaPost);
        this._httpService.get('/api/Dieta/PostNumeroDieta/' + this.metaPost).subscribe();
        window.location.href = "/dieta";
    }

    ngOnInit() {
        this.formGroup = this.formBuilder.group({
            peso: [''],
            altura: [''],
            grasa: [''],
            agua: [''],
            imc: [''],
            kg: [''],
            kacl: [''],
            metas: ['']
        });
    }

}
