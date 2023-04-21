import { Guid } from "guid-typescript";

export interface IDegreeProgressDto{
    userId: Guid,
    totalDegreeEtcsPoints: number,
    reachedEtcsPoints: number,
    openEtcsPoints: number,
    missingEtcsPoints: number,
    missedEctsPoints: number,
    percentageFinishedRequiredModuls: number
}