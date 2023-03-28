import { Guid } from "guid-typescript";

export interface ISemesterDto {
    id: Guid;
    Number: Number;
    SemesterPlannerDtos: []
}
