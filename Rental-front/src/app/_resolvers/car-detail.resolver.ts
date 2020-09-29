import { AlertifyService } from './../_services/alertify.service';
import { CarService } from './../_services/car.service';
import { Car } from './../_models/car';
import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, Router} from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError} from 'rxjs/operators';


@Injectable()

export class CarDetailResolver implements Resolve<Car> {

    constructor( private carService : CarService ,
        private router : Router ,
        private alertify : AlertifyService){ 

    } 

    resolve (route : ActivatedRouteSnapshot) : Observable<Car> {

        return this.carService.getCar(route.params['id']).pipe (
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/car']);
                return of(null);
            })
        );
    }

}