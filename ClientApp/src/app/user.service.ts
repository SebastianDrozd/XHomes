import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from 'src/api-authorization/authorize.service';
import { ICustomer } from './ICustomer';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  customer : ICustomer ;
  
  constructor(private http : HttpClient) {
    
   }

  setCustomer(customer : ICustomer){
  
    this.customer = customer;
      
  }

  getCustomer(){
    return this.customer;
  }
  saveCustomer(customer : ICustomer){
    console.log("initiating save")
    return this.http.post<any>("https://localhost:5001/api/Customers",customer);
  }
}
