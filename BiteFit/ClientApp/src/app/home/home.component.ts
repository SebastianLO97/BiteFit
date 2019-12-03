import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

    redirigir() {
        document.getElementById("divQueHacemos").scrollIntoView(true); 
    }
    redirigir1() {
        document.getElementById("divArticulos").scrollIntoView(true);
    }

    ngOnInit() {

       
  }

}
