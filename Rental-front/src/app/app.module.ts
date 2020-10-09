import { BookedCarResolver } from './_resolvers/booked-car.resolver';
import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { CarDetailResolver } from './_resolvers/car-detail.resolver';
import { CarService } from './_services/car.service';
import { appRoutes } from './../routes';
import { RouterModule } from '@angular/router';
import { AuthService } from './_services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from  '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatTabsModule} from '@angular/material/tabs';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarComponent } from './car/car.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { UserEditComponent } from './user-edit/user-edit.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { UserBookingsComponent } from './user-bookings/user-bookings.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AdminComponent } from './admin/admin.component';
import { AddcarComponent } from './admin/addcar/addcar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatExpansionModule} from '@angular/material/expansion';
import {A11yModule} from '@angular/cdk/a11y';





 
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    CarComponent,
    CarDetailComponent,
    UserEditComponent,
    CheckoutComponent,
    UserBookingsComponent,
    AdminComponent,
    AddcarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTabsModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    Ng2SearchPipeModule,
    BrowserAnimationsModule,
    MatExpansionModule,
    A11yModule
    
  ],
  providers: [
    AuthService,
    CarService,
    CarDetailResolver,
    UserEditResolver,
    BookedCarResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
