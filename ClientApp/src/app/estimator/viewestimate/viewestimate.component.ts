import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import * as internal from "assert";
import { EstimatorService } from "../estimator.service";
import { ISummaryEstimate } from "../summary/Estimate";
import _swal from "sweetalert";
@Component({
  selector: "app-viewestimate",
  templateUrl: "./viewestimate.component.html",
  styleUrls: ["./viewestimate.component.css"],
})
export class ViewestimateComponent implements OnInit {
  id: string;
  constructor(
    private _Activatedroute: ActivatedRoute,
    private estimatorSerice: EstimatorService,
    private router: Router
  ) {}
  estimate = {};
  estimates = [];
  coun: number;
  tasks: [];
  materials: [];

  ngOnInit() {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this.estimate = this.estimatorSerice.getEstimate();
    console.log(this.estimate);
    //@ts-ignore
    this.tasks = this.estimate.tasks;
    //@ts-ignore
    this.materials = this.estimate.materials;
  }

  getAllEstimates() {}

  getEstimate() {}

  deleteEstimate() {
    _swal("Are you sure?", "Delete this estimate permanently", "error").then(
      function () {
        console.log("id is", this.estimate.id);
      }
    );
  }
}
