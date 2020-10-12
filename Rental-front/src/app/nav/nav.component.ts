import { User } from './../_models/user';
import { UserService } from './../_services/User.service';
import { AlertifyService } from './../_services/alertify.service';

import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from './../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  
  model:any ={};
  user:User;
  id:number;
 
  
  



  constructor(public authService: AuthService , private alertify : AlertifyService , private router:Router,
    private userservice : UserService) { }

  ngOnInit() {
    
 

  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      
        this.alertify.success('Logged in successfully');
        this.authService.hideRegister=false;
        

        
      }, error => {
        this.alertify.error('Invalid Credentials');
      },() => {
        this.router.navigate(['/car']);
      });
    
  }

  loggedIn(){
   return this.authService.loggedIn();
  }

  logout(){
    
    this.authService.hideRegister=true;
    
    localStorage.removeItem('token');
    this.authService.hideRegister=true;
    this.alertify.message("Logged Out");
    this.router.navigate(['/home']);

  }

  isadmin(){
    
    this.authService.isAdmin();
    return this.authService.admin;
    
  }

  // isAdmin(){
  //   this.authService.getUser(this.authService.decodedToken.nameid).subscribe(response => {
  //     this.user=response;
      
  //   }, error => {
  //     console.log(error);
  //   });
  // }


  }



 

