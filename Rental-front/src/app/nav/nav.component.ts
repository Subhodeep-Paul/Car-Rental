import { AlertifyService } from './../_services/alertify.service';

import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from './../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  
  model:any ={};

  constructor(public authService: AuthService , private alertify : AlertifyService) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
        this.alertify.success('Logged in successfully');

        this.authService.hideRegister=false;
      }, error => {
        this.alertify.error('Invalid Credentials');
      });
    
  }

  loggedIn(){
    
   return this.authService.loggedIn();
  }

  logout(){

    localStorage.removeItem('token');
    this.authService.hideRegister=true;
    this.alertify.message("Logged Out");
  }

 
}
