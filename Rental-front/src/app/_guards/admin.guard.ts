import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private authservice :AuthService , private router : Router , private alertify : AlertifyService){}
  canActivate(): boolean {

    
    if (this.authservice.loggedIn())
    {
        this.authservice.isAdmin();
        if(this.authservice.admin)
        return true;
    }
    

    this.alertify.error('Access denied');
    this.router.navigate(['/admin']);
    return false;
  }

}