import { Component, OnInit } from '@angular/core';
import { EstimatorService } from './estimator.service';
import { ISummaryEstimate } from './summary/Estimate';
import { FinishedEstimate } from './work-summary/FinishedEstimate';

@Component({
  selector: 'app-estimator',
  templateUrl: './estimator.component.html',
  styleUrls: ['./estimator.component.css']
})
export class EstimatorComponent implements OnInit {

  estimates : []

  constructor(private estimatorService : EstimatorService) { }

  ngOnInit() {
      this.estimatorService.getAllEstimate().subscribe(data => this.estimates = data)
  }

  button(){
    console.log(this.estimates)
  }

  deleteEstimate(input){
    this.estimatorService.deleteEstimate(input).subscribe(data => console.log(data))
    this.estimatorService.getAllEstimate().subscribe(data => this.estimates = data)
  }

}
