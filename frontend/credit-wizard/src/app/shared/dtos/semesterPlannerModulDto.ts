import { Guid } from "guid-typescript";
import { ISemesterPlannnerDto } from "./semesterPlannerDto";
import { IModulDto } from "./modulDto";

export interface ISemesterPlannerModulDto {
    semesterPlannerId: Guid,
    semesterPlannerDto?: ISemesterPlannnerDto,
    modulId: Guid,
    modulDto?: IModulDto,
    grade?: number
}
