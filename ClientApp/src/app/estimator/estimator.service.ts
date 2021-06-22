import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ISummaryEstimate } from "./summary/Estimate";
import { FinishedEstimate } from "./work-summary/FinishedEstimate";

@Injectable({
  providedIn: "root",
})
export class EstimatorService {
  constructor(private http: HttpClient) {}

  estimate: {};
  getAllEstimate() {
    return (this.estimate = this.http.get<any>(
      "https://localhost:5001/api/Estimates"
    ));
  }

  deleteEstimate(input) {
    return this.http.delete(`https://localhost:5001/api/Estimates/${input}`);
  }

  viewEstimate(estimate) {
    console.log(estimate);
  }

  setEstimate(estimate) {
    this.estimate = estimate;
    console.log("this is estimate from service", estimate);
  }

  getEstimate() {
    return this.estimate;
  }
}
