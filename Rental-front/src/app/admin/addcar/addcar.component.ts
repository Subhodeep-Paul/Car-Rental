import { CarService } from './../../_services/car.service';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-addcar',
  templateUrl: './addcar.component.html',
  styleUrls: ['./addcar.component.css']
})
export class AddcarComponent implements OnInit {
  carForm: FormGroup;

  constructor(private fb:FormBuilder, private carservice:CarService) { }

  ngOnInit(): void {
    this.createCarForm();
  }

  createCarForm(){
    this.carForm=this.fb.group({
      company : new FormControl(null ,Validators.required),
      model : new FormControl(null,Validators.required),
      distance: new FormControl(null,Validators.required),
      seats :new FormControl(null,Validators.required),
      fuel:new FormControl(null,Validators.required),
      transmission:new FormControl(null,Validators.required),
      available :new FormControl(true),
      price:new FormControl(null,Validators.required)
      
      
    });

  }

  addCar(){
    this.carservice.addCar(this.carForm.value).subscribe(() => {
      alert("Car added");
      this.carForm.reset();
    }, error => {
      console.log(error);
    })
  }
}
