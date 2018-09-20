export interface IVenue {
    venueId?;
    venueName?;
    description?;
}

export class Venue implements IVenue {
    constructor (public venueId?, public venueName?, public description?) 
    {
        
    }
}