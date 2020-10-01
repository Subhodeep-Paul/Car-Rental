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

    {path : '', component : HomeComponent},
    {path : 'car', component : CarComponent , canActivate:[AuthGuard]},
    {path : 'car/:id', component : CarDetailComponent , canActivate:[AuthGuard] , resolve: {car : CarDetailResolver}},

    {path : 'user/edit', component : UserEditComponent , canActivate:[AuthGuard],resolve: {user : UserEditResolver}},
    {path : 'register', component : RegisterComponent , canActivate:[AuthGuard]} ,
    {path : 'checkout', component : CheckoutComponent , canActivate:[AuthGuard],resolve: {userdetail : UserEditResolver}},

    {path : '**', redirectTo:'' , pathMatch: 'full'}


];


