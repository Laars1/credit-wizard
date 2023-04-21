import { Guid } from "guid-typescript";
import { IDegreeModulDto } from "./degreeModulDto";

export interface IDegreeDto {
    id: Guid,
    name: string,
    description: string
    degreeModulDtos: IDegreeModulDto[]
}
