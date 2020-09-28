import { AuthGuard } from './app/_guards/auth.guard';
import { RegisterComponent } from './app/register/register.component';
import { CarComponent } from './app/car/car.component';
import { HomeComponent } from './app/home/home.component';
import {Routes } from '@angular/router';


export const appRoutes : Routes = [

    {path : '', component : HomeComponent},
    {path : 'car', component : CarComponent , canActivate:[AuthGuard]},

    {path : 'register', component : RegisterComponent},

    {path : '**', redirectTo:'' , pathMatch: 'full'}


];


