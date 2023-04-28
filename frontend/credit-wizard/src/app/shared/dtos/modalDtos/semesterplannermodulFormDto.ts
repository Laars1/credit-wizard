import { Guid } from "guid-typescript";
import { ISemesterPlannerModulDto } from "../semesterPlannerModulDto";
import { FormType } from "../../enums/formType.enum";

export interface ISemesterplannermodulFormDto {
    semesterTimeSlotId: Guid,
    semesterPlannerId: Guid,
    item: ISemesterPlannerModulDto,
    formType: FormType
}
