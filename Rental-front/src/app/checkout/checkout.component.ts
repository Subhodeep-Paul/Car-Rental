import { AlertifyService } from './../_services/alertify.service';
import { BookingService } from './../_services/booking.service';
import { Car } from './../_models/car';
import { CarService } from './../_services/car.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../_models/user';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DateInput } from 'ngx-bootstrap/chronos/test/chain';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  user : User;
  cardetails: Car;
  price;
  months: number;
  checkoutForm : FormGroup;
  date: Date;
  model : any;
 


  constructor(private route: ActivatedRoute, public carservice : CarService,
    private fb : FormBuilder, private bookservice: BookingService, private alertify: AlertifyService,
    private router: Router) { }

  ngOnInit(): void {

    this.months=parseInt(sessionStorage.getItem("month"));
   

    this.route.data.subscribe(data => {
      this.user= data['userdetail'];
    });

    this.route.data.subscribe(data => {
      this.cardetails = data['car'];
    });

   
    this.price= this.months*this.cardetails.a_PRICE;
    this.createCheckoutForm();



  }

  createCheckoutForm(){
    this.checkoutForm=this.fb.group({
      Tenure : new FormControl(this.months ),
      startDate : new FormControl(null, Validators.required),
      endDate : new FormControl({ value: ''}),
      Price : new FormControl(this.price),
      CarId : new FormControl(this.cardetails.a_ID),
      UserId : new FormControl(this.user.a_ID)
      
    });
  }

    Book(){
     
      this.model=this.checkoutForm.value;
      this.date=new Date(this.model['startDate']);
      if(!(this.date.getDate() >= new Date().getDate())){
        alert("Please select a correct start date");
        return;
      }
      
      this.date=new Date(this.date.setDate(this.date.getDate() + 30*this.months));
      this.checkoutForm.controls['endDate'].setValue(this.date.toISOString().substring(0,10));
      console.log(this.checkoutForm);
      this.model=this.checkoutForm.value;

      console.log(this.model);

      var c = confirm("Confirm Booking ?");

      if(c){
        this.bookservice.book(this.model).subscribe(() => {
          console.log('booking done');
          this.checkoutForm.reset();
          this.alertify.success("Booking Done");
       }, error => {
         console.log(error);
         this.alertify.error("Error");
       }, () => {
         this.router.navigate(['/bookings']);
       })
 
       
       this.carservice.update(this.cardetails.a_ID).subscribe( response=>{
         this.cardetails=response;
         console.log(this.cardetails.a_ID);
         console.log(this.cardetails.a_IS_AVAILABLE);
        });
 
       
 
      }


    }
  


 
  
}
