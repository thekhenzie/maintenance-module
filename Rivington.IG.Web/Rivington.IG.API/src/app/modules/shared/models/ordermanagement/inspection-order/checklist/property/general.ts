import { City } from "../../../city";
import { State } from "../../../state";
import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyGeneralDomesticHelpTypes } from "./general/InspectionOrderPropertyGeneralDomesticHelpTypes";
import { InspectionOrderPropertyGeneralPolicyPremiumCredits } from "./general/InspectionOrderPropertyGeneralPolicyPremiumCredits";
import { InspectionOrderPropertyGeneralWildfireCredits } from "./general/InspectionOrderPropertyGeneralWildfireCredits";
import { BurglarAlarm } from "./general/burglar-alarm";
import { BurglarAlarmType } from "./general/burglar-alarm-type";
import { FireAlarm } from "./general/fire-alarm";
import { FireAlarmType } from "./general/fire-alarm-type";
import { OccupancyType } from "./general/occupancy-type";
import { SmokeOnlyAlarm } from "./general/smoke-only-alarm";
import { SmokeOnlyAlarmType } from "./general/smoke-only-alarm-type";
import { DomesticHelp } from "./general/domestic-help";

export class InspectionOrderPropertyGeneral {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    id?: string;
    streetAddress1?: string;
    streetAddress2?: string;
    cityId?: number;
    /*[ForeignKey(nameof(CityId))]*/
    city?: City;
    stateId?: string;
    /*[ForeignKey(nameof(StateId))]*/
    state?: State;
    zipCode?: string;
    estimatedSquareFootage?: number;
    yearBuilt?: number;
    recentlyRenovated?: boolean;
    contractorName?: string;
    contractorPhone?: string;
    roofAge?: number;
    waterHeaterAge?: number;
    majorSystemAge?: number;
    majorSystemDescription?: string;
    pre1970Updates?: boolean;
    pre1970UpdatesDescription?: string;
    septicTank?: boolean;
    lastServiceDate?: string;
    priorLoss?: boolean;
    priorLossDescription?: string;
    problemResolved?: boolean;
    occupancyTypeId?: string;
    /*[ForeignKey(nameof(OccupancyTypeId))]*/
    occupancyType?: OccupancyType;
    domesticHelpTypeId?: string;
    /*[ForeignKey(nameof(domesticHelpTypeId))]*/
    domesticHelp?: DomesticHelp;
    domesticHelpTypes?: InspectionOrderPropertyGeneralDomesticHelpTypes[];
    fireAlarmId?: string;
    /*[ForeignKey(nameof(FireAlarmId))]*/
    fireAlarm?: FireAlarm;
    fireAlarmTypeId?: string;
    /*[ForeignKey(nameof(FireAlarmTypeId))]*/
    fireAlarmType?: FireAlarmType;
    smokeOnlyAlarmId?: string;
    /*[ForeignKey(nameof(SmokeOnlyAlarmId))]*/
    smokeOnlyAlarm?: SmokeOnlyAlarm;
    smokeOnlyAlarmTypeId?: string;
    /*[ForeignKey(nameof(SmokeOnlyAlarmTypeId))]*/
    smokeOnlyAlarmType?: SmokeOnlyAlarmType;
    burglarAlarmId?: string;
    /*[ForeignKey(nameof(BurglarAlarmId))]*/
    burglarAlarm?: BurglarAlarm;
    burglarAlarmTypeId?: string;
    /*[ForeignKey(nameof(BurglarAlarmTypeId))]*/
    burglarAlarmType?: BurglarAlarmType;
    woodStoveOrWoodBurningFirePlace?: boolean;
    woodStoveLocation?: string;
    woodStoveUsage?: string;
    policyPremiumCredits?: InspectionOrderPropertyGeneralPolicyPremiumCredits[];
    wildfireCredits?: InspectionOrderPropertyGeneralWildfireCredits[];
    
    public constructor(init?:Partial<InspectionOrderPropertyGeneral>) {
        Object.assign(this, init);
    }
}