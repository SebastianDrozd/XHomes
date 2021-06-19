import { Injectable } from '@angular/core';
import { ITast } from './ITask';
import { IWorkSummary } from './IWorkSummary';

@Injectable({
  providedIn: 'root'
})
export class WorkService {

  tasks : ITast [] = []

  workEstimate : IWorkSummary;
  constructor() { }

  addTask(task : ITast){
    this.tasks.push(task)
  }

  addWorkEstimate(input,tasks){
    this.workEstimate = {jobType: input.jobType, difficulty : input.difficulty, condition: input.condition, workDescription: input.workDescription, tasks : tasks}
    console.log(this.workEstimate)
  }

  addTasks(tasks : ITast []){
      this.tasks = tasks;
      console.log(this.tasks)
  }

  getEstimate(){
    return this.workEstimate
  }
}
