import { Guid } from "guid-typescript";
import { IUserDto } from "./userDto";
import { ISemesterDto } from "./semesterDto";
import { ISemesterPlannerModulDto } from "./semesterPlannerModulDto";
import { ISemesterTimeSlotDto } from "./semesterTimeSlotDto";

export interface ISemesterPlannnerDto{
    id: Guid,
    userId: Guid,
    user: IUserDto,
    completed: boolean,
    semesterId: boolean,
    semesterDto: ISemesterDto,
    semesterPlannerModulDtos: ISemesterPlannerModulDto[],
    semesterTimeSlotId: Guid,
    semesterTimeSlotDto: ISemesterTimeSlotDto
}