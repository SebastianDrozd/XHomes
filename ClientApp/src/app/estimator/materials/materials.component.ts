import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { discardPeriodicTasks } from '@angular/core/testing';
import { Router } from '@angular/router';
import { IMaterial } from './IMaterial';
import { IMaterialSummary } from './IMaterialSummary';
import { MaterialService } from './material.service';

@Component({
  selector: 'materials',
  templateUrl: './materials.component.html',
  styleUrls: ['./materials.component.css']
})
export class MaterialsComponent implements OnInit {
  materials : IMaterial [] = []
  private router : Router;
  constructor(router : Router, private materialService : MaterialService) {
    this.router = router;
   }
   material : IMaterial;
  ngOnInit() {
  }

  transfer(input){
    console.log(input)
    this.materialService.addMaterialSummary(input, this.materials)
    this.router.navigateByUrl('estimator/summary')
  }

  addMaterial(material : IMaterial){
    this.material = {material : material.material, matDescription: material.matDescription, price : material.price};

    this.materials.push(this.material)
  }
  deleteTask(task){
    this.materials= this.materials.filter(x => x.material !== task.material)
  }

}
