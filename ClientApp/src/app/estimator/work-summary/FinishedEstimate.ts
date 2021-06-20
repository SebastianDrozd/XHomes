import { IMaterial } from "../materials/IMaterial";
import { ITast } from "./ITask";

export interface FinishedEstimate{
        id: number;
        firstName: string;
        lastName: string;
        city: string;
        state: string;
        zip: string;
        phone: string;
        email: string;
        description: string;
        jobType: string;
        difficulty:number;
        condition: number;
        workDescription: string;
        tasks: ITast []
        matDescription: string,
        materials: IMaterial[],
        fileName: string,
        filePath: string
}