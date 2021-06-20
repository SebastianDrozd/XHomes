import { IMaterial } from "../materials/IMaterial";
import { ITast } from "../work-summary/ITask";

export interface ISummaryEstimate{
    firstName : string;
    lastName : string;
    city : string;
    state : string;
    zip : string;
    phone : string;
    email : string;
    description : string;
    jobType : string;
    condition : number;
    difficulty : number;
    tasks : ITast[];
    matDescription : string;
    materials : IMaterial [];
}