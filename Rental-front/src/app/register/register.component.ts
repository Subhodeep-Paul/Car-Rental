import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component,Output, EventEmitter, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister =new EventEmitter();

  model : any ={};

  constructor(private authservice:AuthService, private alertify : AlertifyService) { }

  ngOnInit(): void {
  }

  register(registerForm : NgForm){

    this.authservice.register(this.model).subscribe(() => {
      this.alertify.success("Registration Successful");
      registerForm.reset();
    }, error => {
      
      this.alertify.error(error.error);
      registerForm.reset();
    });
    }

    cancel(){
      this.cancelRegister.emit(false);
      console.log('cancelled');
    }

}
