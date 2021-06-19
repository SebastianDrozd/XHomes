import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IUser } from 'src/api-authorization/authorize.service';
import { ICustomer } from 'src/app/ICustomer';

import { UserService } from 'src/app/user.service';

@Component({
  selector: 'user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {
  
  private custService : UserService;
  firstName : string = ""
  constructor(private router : Router, custService : UserService) {
    this.custService = custService;
   }

  ngOnInit() {
  }

  continue(){
    this.router.navigateByUrl('customer/work');
  }

  transfer(customer : ICustomer){
    console.log(customer)
    if(customer.save == true){
      this.custService.saveCustomer(customer).subscribe(data => console.log(data));
    }
    else{
      this.custService.setCustomer(customer) 
    } 
    this.router.navigateByUrl('estimator/work');
  }



}
