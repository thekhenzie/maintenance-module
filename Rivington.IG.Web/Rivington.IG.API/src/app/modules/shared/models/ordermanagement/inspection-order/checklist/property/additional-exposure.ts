import { DogTemperament } from "./additional-exposure/dog-temperament";
import { CustomerOnSite } from "./additional-exposure/customer-on-site";
import { Employee10HoursPerWeek } from "./additional-exposure/employee-10-hours-per-week";
import { BearInvasionConcernDetail } from "./additional-exposure/bear-invasion-concern-detail";
import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails } from "./additional-exposure/InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails";

export class InspectionOrderPropertyAdditionalExposure {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    /*[Key]*/
    id?: string;
    trampoline?: boolean;
    safetyNetting?: boolean;
    bracingBolting?: boolean;
    skateboardRamp?: boolean;
    otherAttractiveNuisance?: boolean;
    otherAttractiveNuisanceComment?: string;
    adjacentExposure?: boolean;
    adjacentExposureComment?: string;
    dog?: boolean;
    numberofDog?: number;
    dogBreed?: string;
    dogTemperamentId?: string;
    /*[ForeignKey(nameof(DogTemperamentId))]*/
    dogTemperament?: DogTemperament;
    biteHistory?: boolean;
    businessAgricultureonPremises?: boolean;
    businessAgricultureType?: string;
    customerOnSiteId?: string;
    /*[ForeignKey(nameof(CustomerOnSiteId))]*/
    customerOnSite?: CustomerOnSite;
    employee10HoursPerWeekId?: string;
    /*[ForeignKey(nameof(Employee10HoursPerWeekId))]*/
    employee10HoursPerWeek?: Employee10HoursPerWeek;
    horsesFarmAnimalsonPremise?: boolean;
    horsesFarmAnimalCount?: number;
    horsesFarmAnimalType?: string;
    daycareonSite?: boolean;
    bearInvasionConcern?: boolean;
    bearInvasionConcernDetails?: InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails[];
    additionalConcern?: boolean;
    additionalComment?: string;
    public constructor(init?:Partial<InspectionOrderPropertyAdditionalExposure>) {
        Object.assign(this, init);
    }
  }