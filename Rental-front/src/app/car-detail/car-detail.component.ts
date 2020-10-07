import { User } from './../_models/user';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
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
  month : number;
  user:User;

  months:any = [1,2,3,4,5,6,7,8,9,10,11,12];

  constructor(private carService : CarService , private alertify : AlertifyService,
    private route :ActivatedRoute , private fb:FormBuilder) { }

  ngOnInit(): void {
    //this.loadCar();

    this.route.data.subscribe(data => {
      this.carvalue = data['car'];
    });

    //getting user data to disable proceed to checkout button
    this.route.data.subscribe(data => {
      this.user= data['user'];
    });


    
  }

  monthForm = this.fb.group({
    month :[]
  })

  monthAdd( ) {
    this.carService.addSubscriptionTenure(this.monthForm.get('month').value);
    
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
