import { UserService } from './../../_services/User.service';
import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/_models/car';
import { CarService } from 'src/app/_services/car.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-viewcar',
  templateUrl: './viewcar.component.html',
  styleUrls: ['./viewcar.component.css']
})
export class ViewcarComponent implements OnInit {

  carValues : Car[];
  search;


  constructor(private carService : CarService, private alertify : AlertifyService) { }

  ngOnInit(): void {
    this.getAllCars();
  }

  getAllCars(){
    this.carService.getAllCars().subscribe(response => {
      this.carValues=response;
      console.log(this.carValues);
    }, error => {
      console.log(error);
    })
  }

  deleteCar(id){
    var c=confirm('Confirm delete?');
    if (c)
    {
      this.carService.delete(id).subscribe(() =>{
        location.reload();
      }, error => {
        console.log(error);
      });
    }
   
    
  }





}
