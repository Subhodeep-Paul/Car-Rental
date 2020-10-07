import { BookedCarResolver } from './app/_resolvers/booked-car.resolver';
import { UserBookingsComponent } from './app/user-bookings/user-bookings.component';
import { CheckoutComponent } from './app/checkout/checkout.component';
import { UserEditResolver } from './app/_resolvers/user-edit.resolver';
import { UserEditComponent } from './app/user-edit/user-edit.component';
import { CarDetailResolver } from './app/_resolvers/car-detail.resolver';
import { AuthGuard } from './app/_guards/auth.guard';
import { RegisterComponent } from './app/register/register.component';
import { CarComponent } from './app/car/car.component';
import { HomeComponent } from './app/home/home.component';
import {Routes } from '@angular/router';
import { CarDetailComponent } from './app/car-detail/car-detail.component';


export const appRoutes : Routes = [

    {path : 'home', component : HomeComponent},
    {path : 'car', component : CarComponent , canActivate:[AuthGuard]},
    {path : 'car/:id', component : CarDetailComponent , canActivate:[AuthGuard] , resolve: {car : CarDetailResolver,user : UserEditResolver}},

    {path : 'user/edit', component : UserEditComponent , canActivate:[AuthGuard],resolve: {user : UserEditResolver}},
    {path : 'register', component : RegisterComponent } ,
    {path : 'bookings', component : UserBookingsComponent , canActivate:[AuthGuard],resolve: {user : UserEditResolver}} ,
    {path : 'checkout/:id', component : CheckoutComponent , canActivate:[AuthGuard],resolve: {userdetail : UserEditResolver, car: CarDetailResolver}},

    {path : '**', redirectTo:'home' , pathMatch: 'full'}


];


