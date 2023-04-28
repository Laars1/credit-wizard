import { Guid } from "guid-typescript";
import { IDegreeModulDto } from "src/app/shared/dtos/degreeModulDto";
import { FormType } from "src/app/shared/enums/formType.enum";

export interface ISelectModul {
    name: string,
    degreeModulDto: IDegreeModulDto[],
}
