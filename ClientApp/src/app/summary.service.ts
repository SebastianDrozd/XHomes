import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISummaryEstimate } from './estimator/summary/Estimate';

@Injectable({
  providedIn: 'root'
})
export class SummaryService {

  constructor(private http : HttpClient) { }


  downloadDocument(estimate : ISummaryEstimate){
    console.log("service" , estimate)

    return this.http.post("https://localhost:5001/api/Estimates", estimate , { responseType: 'blob'});
  }
}
