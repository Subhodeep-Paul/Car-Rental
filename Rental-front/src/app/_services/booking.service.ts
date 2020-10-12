import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  carid:number;

  baseUrl =environment.apiUrl + 'checkout/';

  constructor(private http: HttpClient) { }

  
  book(model:any){

    return this.http.post(this.baseUrl  ,model );

  }

  delete(id){
    return this.http.delete(this.baseUrl +id);
  }

  getCar(id : number)
  {
      this.carid=id;
      
  }


}
