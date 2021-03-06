import { Car } from './../_models/car';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CarService {

  months: number;

  baseUrl =environment.apiUrl;

constructor(private http : HttpClient) { }

 getAllCars(): Observable<Car[]>{
  return this.http.get<Car[]>(this.baseUrl+'car');
 }

 getCar(id):Observable<Car>{
  return this.http.get<Car>(this.baseUrl + 'car/' +id);
 }

 addCar(carmodel:Car){
  return this.http.post(this.baseUrl + 'car/add',carmodel);
 }

 addSubscriptionTenure(tenure : number){
  this.months=tenure;
  sessionStorage.setItem("month",this.months.toLocaleString());
 }
 
 update(id):Observable<Car>{
  return this.http.put<Car>(this.baseUrl + 'car/' +id, {});
 }

 updateDetails(id, updatemodel:any):Observable<Car>{
   return this.http.put<Car>(this.baseUrl +'car/edit/'+id , updatemodel);
 }

 delete(id){
  return this.http.delete(this.baseUrl +'car/'+id);
}









}
