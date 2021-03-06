import { AlertifyService } from './../_services/alertify.service';
import { CarService } from './../_services/car.service';
import { Car } from './../_models/car';
import { BookingService } from './../_services/booking.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../_models/user';

@Component({
  selector: 'app-user-bookings',
  templateUrl: './user-bookings.component.html',
  styleUrls: ['./user-bookings.component.css']
})
export class UserBookingsComponent implements OnInit {
  panelOpenState = false;
  user : User;
  carid:number;
  car:Car;

  constructor(private route: ActivatedRoute, private bookingservice:BookingService, private carservice: CarService,
    private alertify:AlertifyService) { }

  ngOnInit(): void {
    

    this.route.data.subscribe(data => {
      this.user= data['user'];
    });

    
    
    if(this.user.a_BOOKING.length>0)
    this.getCar();

    

   

    // this.route.data.subscribe(data => {
    //   this.car = data['car'];
    // });


  }

  getCar(){
    this.bookingservice.getCar(this.user.a_BOOKING[0].a_FK_CARID);
    this.carservice.getCar(this.bookingservice.carid).subscribe(response => {
      this.car=response;
    }, error => {
      console.log(error);
    })
  }

  deleteBooking(){

    var c = confirm("Are you sure you want to delete this booking?");
    if (c)
      {
        this.bookingservice.delete(this.user.a_BOOKING[0].a_ID).subscribe(() =>{
          location.reload();
         }, error => {
           alert(error);
         });

        
      }

      this.carservice.update(this.user.a_BOOKING[0].a_FK_CARID).subscribe( );
   
  }

}
