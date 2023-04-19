import { Guid } from "guid-typescript";
import { IDegreeDto } from "./degreeDto";

export interface IUserDto {
    id: Guid,
    email: string,
    prename: string,
    lastname: string,
    matriculationNumber: string,
    degreeId: Guid,
    degreeDto: IDegreeDto,
}
