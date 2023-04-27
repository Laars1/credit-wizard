import { Guid } from "guid-typescript";
import { ISemesterPlannerModulDto } from "../semesterPlannerModulDto";

export interface ISemesterplannermodulFormDto {
    semesterTimeSlotId: Guid,
    semesterPlannerId: Guid,
    item: ISemesterPlannerModulDto
}
