import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/api-authorization/authorize.service';
import { ICustomer } from 'src/app/ICustomer';
import { SummaryService } from 'src/app/summary.service';


import { UserService } from 'src/app/user.service';
import { IMaterial } from '../materials/IMaterial';
import { IMaterialSummary } from '../materials/IMaterialSummary';
import { MaterialService } from '../materials/material.service';
import { ITast } from '../work-summary/ITask';
import { IWorkSummary } from '../work-summary/IWorkSummary';
import { WorkService } from '../work-summary/work.service';
import { ISummaryEstimate } from './Estimate';
import { saveAs } from 'file-saver';
@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {
  customer : ICustomer;
  workEstimate : IWorkSummary;
  materialSummary : IMaterialSummary;
  materials : IMaterial [] = []
  tasks : ITast [] = []

  estimate : ISummaryEstimate;

  private custService : UserService;
  constructor(custService : UserService, private workService : WorkService,private materialService : MaterialService ,private summaryService : SummaryService) {
    this.custService = custService;
   }

  ngOnInit() {
    this.customer = this.custService.getCustomer();
    this.workEstimate = this.workService.getEstimate();
    this.materialSummary = this.materialService.getMaterialSummary();
    this.materials = this.materialSummary.materials; 
    this.tasks = this.workEstimate.tasks;
  }

  download(){
    this.estimate = {firstName : this.customer.firstName, lastName : this.customer.lastName, city: this.customer.city, state : this.customer.state, zip : this.customer.zip, phone: this.customer.phone, email : this.customer.email, description: this.customer.description }
      console.log(this.estimate)
      this.summaryService.downloadDocument(this.estimate).subscribe(blob => saveAs(blob, 'Sebastian.docx'));
  }

  downLoadFile(data: any, type: string) {
    let blob = new Blob([data], { type: type});
    let url = window.URL.createObjectURL(blob);
    let pwa = window.open(url);
    if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
        alert( 'Please disable your Pop-up blocker and try again.');
    }

}
}
