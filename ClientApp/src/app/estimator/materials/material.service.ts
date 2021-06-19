import { Injectable } from '@angular/core';
import { IMaterialSummary } from './IMaterialSummary';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  materialSummary : IMaterialSummary;
  constructor() { }


  addMaterialSummary(input, tasks){
    this.materialSummary = {description : input.description, materials: tasks}

    console.log("Endpoint object",this.materialSummary)
  }


  getMaterialSummary(){
    return this.materialSummary;
  }

}
