import { Guid } from "guid-typescript";

export interface IModulDto {
    id: Guid;
    abbreviation: string;
    name: string;
    description: string;
    etcsPoints: number;
}
