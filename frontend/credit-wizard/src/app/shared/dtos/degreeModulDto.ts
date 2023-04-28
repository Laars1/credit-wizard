import { Guid } from "guid-typescript";
import { IDegreeDto } from './degreeDto';
import { IModulDto } from "./modulDto";

export interface IDegreeModulDto {
    modulId: Guid,
    degreeId: Guid,
    modulDto: IModulDto,
    degreeDto: IDegreeDto,
    isRequired: boolean
}
