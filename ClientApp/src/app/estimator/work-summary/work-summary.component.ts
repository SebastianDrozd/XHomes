import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/api-authorization/authorize.service';
import { Router } from '@angular/router';
import { ITast } from './ITask';
import { InstallPackageOptions } from 'typescript';
import { WorkService } from './work.service';
@Component({
  selector: 'work-summary',
  templateUrl: './work-summary.component.html',
  styleUrls: ['./work-summary.component.css']
})
export class WorkSummaryComponent implements OnInit {
 
  private router : Router
  constructor( router : Router, private workService : WorkService) { 
    this.router = router;
  }
  id : number = 0;
  tasks : ITast [] = [ ]
  task : ITast;
          
  ngOnInit() {
  }

  addTasks(task : ITast){
    this.tasks.push(task);
  }

  addTask(input)
  {
    this.id = this.id + 1;
    this.task = { title: input.title, description : input.description, priority : input.priority}
    
      console.log("Input from addtask form is ",input)

      this.tasks.push(this.task);

  }

  deleteTask(task : ITast){
    this.tasks = this.tasks.filter(x => x.title !== task.title)
  }

  transfer(input){

    console.log(input)
    
    this.workService.addWorkEstimate(input, this.tasks)

    
    this.router.navigateByUrl('estimator/materials');
  }

}
