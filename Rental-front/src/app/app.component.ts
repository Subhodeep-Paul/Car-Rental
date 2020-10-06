import { CarService } from './_services/car.service';
import { AuthService } from './_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  jwtHelper = new JwtHelperService();

  constructor( private authservice : AuthService, private carservice: CarService){}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token )
    {
      this.authservice.decodedToken= this.jwtHelper.decodeToken(token);
    }

    if(this.authservice.loggedIn())
    this.authservice.hideRegister=false;

    this.carservice.months;
  }

}
