import { Guid } from "guid-typescript";
import { IDegreeModulDto } from "./degreeModulDto";

export interface IModulDto {
    id: Guid;
    abbreviation: string;
    name: string;
    description: string;
    etcsPoints: number;
    degreeModulDtos: IDegreeModulDto[]
}
