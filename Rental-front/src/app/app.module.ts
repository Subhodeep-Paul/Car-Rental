import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { CarDetailResolver } from './_resolvers/car-detail.resolver';
import { CarService } from './_services/car.service';
import { appRoutes } from './../routes';
import { RouterModule } from '@angular/router';
import { AuthService } from './_services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from  '@angular/common/http';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarComponent } from './car/car.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { UserEditComponent } from './user-edit/user-edit.component';

 
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    CarComponent,
    CarDetailComponent,
    UserEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    AuthService,
    CarService,
    CarDetailResolver,
    UserEditResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
