import { AuthService } from './auth.service';
import { User } from './../_models/user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl =environment.apiUrl;
  id:number;

  constructor(private http : HttpClient) { }

  getAllUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl+'user');
  }
  
  getUser(id):Observable<User>{
    return this.http.get<User>(this.baseUrl + 'User/' +id)
  }

  getID(id){
    this.id=id;

  }


}
