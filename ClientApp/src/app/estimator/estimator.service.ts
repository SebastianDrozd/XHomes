import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISummaryEstimate } from './summary/Estimate';
import { FinishedEstimate } from './work-summary/FinishedEstimate';

@Injectable({
  providedIn: 'root'
})
export class EstimatorService {

  constructor(private http : HttpClient) {    
   }

   getAllEstimate(){
     return this.http.get<any>("https://localhost:5001/api/Estimates");
   }

   deleteEstimate(input){
     return this.http.delete(`https://localhost:5001/api/Estimates/${input}`)
   }
}
