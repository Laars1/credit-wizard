import { Guid } from "guid-typescript";

export interface ISemesterDto {
    id: Guid;
    number: Number;
    semesterPlannerDtos: []
}
