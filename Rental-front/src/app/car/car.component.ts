import { Car } from './../_models/car';
import { CarService } from './../_services/car.service';
import { environment } from './../../environments/environment';
import { AlertifyService } from './../_services/alertify.service';
import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

   carValues : Car[];
  baseUrl = environment.apiUrl;


  constructor(private http : HttpClient , private alertify : AlertifyService, private carService : CarService) { }

  ngOnInit(): void {
    this.getValues();
  }

  getValues(){
    this.carService.getAllCars().subscribe(response => {
      this.carValues=response;
      console.log(this.carValues);
    }, error => {
      console.log(error);
    })
  }

 




}
