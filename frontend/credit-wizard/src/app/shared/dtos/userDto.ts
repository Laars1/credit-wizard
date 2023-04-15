import { Guid } from "guid-typescript";
import { DegreeDto } from "./degreeDto";

export interface IUserDto {
    id: Guid,
    email: string,
    prename: string,
    lastname: string,
    matriculationNumber: string,
    degreeId: Guid,
    degreeDto: DegreeDto,
}
