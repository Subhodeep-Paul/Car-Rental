import { UserService } from './../_services/User.service';
import { AuthService } from './../_services/auth.service';
import { User } from './../_models/user';
import { AlertifyService } from '../_services/alertify.service';
import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, Router} from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError} from 'rxjs/operators';


@Injectable()

export class UserEditResolver implements Resolve<User> {

    constructor( private userservice :UserService ,
        private router : Router ,
        private alertify : AlertifyService,
        private authservice : AuthService){ 

    } 

    resolve (route : ActivatedRouteSnapshot) : Observable<User> {

        return this.userservice.getUser(this.authservice.decodedToken.nameid).pipe (
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['']);
                return of(null);
            })
        );
    }

}