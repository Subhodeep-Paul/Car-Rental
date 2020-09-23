import { AuthService } from './../_services/auth.service';
import { Component,Output, EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister =new EventEmitter();

  model : any ={};

  constructor(private authservice:AuthService) { }

  ngOnInit(): void {
  }

  register(){

    this.authservice.register(this.model).subscribe(() => {
      alert('Registration Successful');
    }, error => {
      console.log(error);
    });
    }

    cancel(){
      this.cancelRegister.emit(false);
      console.log('cancelled');
    }

}
