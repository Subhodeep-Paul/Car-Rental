import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../_models/user';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  @Output() backRegister =new EventEmitter();

  user : User;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {


    this.route.data.subscribe(data => {
      this.user= data['user'];
    });
  }

  goBack(){
    this.backRegister.emit(false);
    
  }

  

}
