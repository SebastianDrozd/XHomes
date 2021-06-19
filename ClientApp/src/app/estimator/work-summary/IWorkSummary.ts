import { ITast } from "./ITask";

export interface IWorkSummary{
    jobType : string;
    difficulty : number;
    condition : number;
    workDescription : string;
    tasks : ITast[];
}