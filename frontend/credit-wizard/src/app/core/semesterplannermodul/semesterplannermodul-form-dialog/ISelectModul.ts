import { Guid } from "guid-typescript";
import { IDegreeModulDto } from "src/app/shared/dtos/degreeModulDto";

export interface ISelectModul {
    name: string,
    degreeModulDto: IDegreeModulDto[],
}
