import { IModulDto } from 'src/app/shared/dtos/modulsDto';
import { Guid } from "guid-typescript";
import { IDegreeDto } from './degreeDto';

export interface IDegreeModulDto {
    modulId: Guid,
    degreeId: Guid,
    modulDto: IModulDto,
    degreeDto: IDegreeDto,
    isRequired: boolean
}
