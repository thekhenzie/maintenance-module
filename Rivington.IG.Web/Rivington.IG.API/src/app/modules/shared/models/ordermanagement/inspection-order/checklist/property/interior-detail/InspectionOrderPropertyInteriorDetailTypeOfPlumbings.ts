import { TypeOfPlumbing } from "./type-of-plumbing";

export class InspectionOrderPropertyInteriorDetailTypeOfPlumbings {
    typeOfPlumbingId?: string;
    /*[ForeignKey(nameof(typeOfPlumbingId))]*/
    typeOfPlumbing?: TypeOfPlumbing;
    public constructor(init?:Partial<InspectionOrderPropertyInteriorDetailTypeOfPlumbings>) {
        Object.assign(this, init);
    }
}