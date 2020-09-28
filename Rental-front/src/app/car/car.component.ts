import { AlertifyService } from './../_services/alertify.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  carValues : any;
  baseUrl = 'http://localhost:5001/api/';


  constructor(private http : HttpClient , private alertify : AlertifyService) { }

  ngOnInit(): void {
    this.getValues();
  }

  getValues(){
    this.http.get(this.baseUrl + 'car').subscribe(response => {
      this.carValues=response;
    }, error => {
      console.log(error);
    })
  }


}
