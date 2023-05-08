import { Guid } from "guid-typescript";
import { IDegreeModulDto } from "./degreeModulDto";
import { ISemesterTimeSlotDto } from "./semesterTimeSlotDto";

export interface IModulDto {
    id: Guid;
    abbreviation: string;
    name: string;
    description: string;
    etcsPoints: number;
    degreeModulDtos: IDegreeModulDto[],
    semesterTimeSlotDtos: ISemesterTimeSlotDto[];
}
