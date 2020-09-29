import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from '../_models/car';
import { AlertifyService } from '../_services/alertify.service';
import { CarService } from '../_services/car.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {

  carvalue: Car;

  constructor(private carService : CarService , private alertify : AlertifyService,
    private route :ActivatedRoute) { }

  ngOnInit(): void {
    //this.loadCar();

    this.route.data.subscribe(data => {
      this.carvalue = data['car'];
    });
  }

  // loadCar(){
  //   this.carService.getCar(+this.route.snapshot.params['id']).subscribe(car => {
  //     this.carvalue=car;
  //     console.log(this.carvalue);
  //   }, error => {
  //     console.log(error);
  //   });
  // }

}
