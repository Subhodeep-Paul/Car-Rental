import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from '../_models/car';
import { AlertifyService } from '../_services/alertify.service';
import { CarService } from '../_services/car.service';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit {
  cardetail: Car;
  editForm: FormGroup;

  constructor(private carservice : CarService , private alertify : AlertifyService,
    private route :ActivatedRoute , private fb:FormBuilder,private router:Router) { }

  ngOnInit(): void {

    this.route.data.subscribe(data => {
      this.cardetail = data['car'];
    });

    this.createEditForm();
  }

  createEditForm(){
    this.editForm=this.fb.group({
      Distance :new FormControl(this.cardetail.a_DISTANCE_DRIVEN),
      Price: new FormControl(this.cardetail.a_PRICE)

    });


  }

  update(){

    this.carservice.updateDetails(this.cardetail.a_ID, this.editForm.value).subscribe(() =>{
          this.editForm.reset();
          this.alertify.success("Updated");
          
    }, error =>{
      console.log(error);
    },() => {
      this.router.navigate(['/admin']);
    });
  }

}
